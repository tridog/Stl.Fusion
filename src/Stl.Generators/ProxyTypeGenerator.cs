using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Stl.Generators;
using static GenerationHelpers;

public class ProxyTypeGenerator
{
    private SourceProductionContext Context { get; }
    private SemanticModel SemanticModel { get; }
    private TypeDeclarationSyntax TypeDef { get; }
    private ITypeSymbol TypeSymbol { get; } = null!;
    private NameSyntax NamespaceRef { get; } = null!;
    private ClassDeclarationSyntax? ClassDef { get; }
    private InterfaceDeclarationSyntax? InterfaceDef { get; }
    private bool IsInterfaceProxy => InterfaceDef != null;
    private bool IsFullProxy { get; }
    private bool IsAsyncProxy => !IsFullProxy;

    private string ProxyTypeName { get; } = "";
    private ClassDeclarationSyntax ProxyDef { get; } = null!;
    private List<MemberDeclarationSyntax> StaticFields { get; } = new();
    private List<MemberDeclarationSyntax> Fields { get; } = new();
    private List<MemberDeclarationSyntax> Properties { get; } = new();
    private List<MemberDeclarationSyntax> Constructors { get; } = new();
    private List<MemberDeclarationSyntax> Methods { get; } = new();
    private Dictionary<ITypeSymbol, string> CachedInterceptFieldNames { get; } = new(SymbolEqualityComparer.Default);
    private List<StatementSyntax> BindMethodStatements { get; } = new();

    public string GeneratedCode { get; } = "";

    public ProxyTypeGenerator(SourceProductionContext context, SemanticModel semanticModel, TypeDeclarationSyntax typeDef)
    {
        Context = context;
        SemanticModel = semanticModel;
        TypeDef = typeDef;
        if (SemanticModel.GetDeclaredSymbol(TypeDef) is not { } typeSymbol)
            return;
        if (TypeDef.GetNamespaceRef() is not { } namespaceRef)
            return;

        TypeSymbol = typeSymbol;
        NamespaceRef = namespaceRef;
        ClassDef = TypeDef as ClassDeclarationSyntax;
        InterfaceDef = TypeDef as InterfaceDeclarationSyntax;
        IsFullProxy = typeSymbol.AllInterfaces.Any(t => Equals(t.ToFullName(), RequiresFullProxyInterfaceName));
        WriteDebug?.Invoke($"{TypeSymbol.ToFullName()}: {(IsFullProxy ? "full" : "async")} proxy");

        ProxyTypeName = TypeDef.Identifier.Text + ProxyClassSuffix;
        ProxyDef = ClassDeclaration(ProxyTypeName)
            .AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.SealedKeyword))
            .WithTypeParameterList(TypeDef.TypeParameterList)
            .WithBaseList(BaseList(CommaSeparatedList<BaseTypeSyntax>(
                SimpleBaseType(TypeDef.ToTypeRef()),
                SimpleBaseType(ProxyInterfaceTypeName))
            ))
            .WithConstraintClauses(TypeDef.ConstraintClauses);

        if (ClassDef != null)
            AddClassConstructors();
        else
            AddInterfaceConstructors();
        AddProxyMethods();
        AddProxyInterfaceImplementation(); // Must be the last one

        ProxyDef = ProxyDef
            .WithMembers(List(
                StaticFields
                .Concat(Fields)
                .Concat(Properties)
                .Concat(Constructors)
                .Concat(Methods)));

        // Building Compilation unit

        var syntaxRoot = SemanticModel.SyntaxTree.GetRoot();
        var proxyNamespaceRef = QualifiedName(NamespaceRef, IdentifierName(ProxyNamespaceSuffix));
        var unit = CompilationUnit()
            .AddUsings(syntaxRoot.ChildNodes().OfType<UsingDirectiveSyntax>().ToArray())
            .AddMembers(FileScopedNamespaceDeclaration(proxyNamespaceRef).AddMembers(ProxyDef));

        var code = unit.NormalizeWhitespace().ToFullString();
        GeneratedCode = "// <auto-generated/>" + Environment.NewLine +
            "#nullable enable" + Environment.NewLine +
            code;
    }

    private void AddInterfaceConstructors()
    {
        var proxyTargetType = NullableType(TypeDef.ToTypeRef());

        Fields.Add(
            PrivateFieldDef(proxyTargetType,
                ProxyTargetFieldName.Identifier,
                LiteralExpression(SyntaxKind.NullLiteralExpression)));

        Constructors.Add(
            ConstructorDeclaration(Identifier(ProxyTypeName))
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(ParameterList())
                .WithBody(Block()));

        Constructors.Add(
            ConstructorDeclaration(Identifier(ProxyTypeName))
                .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                .WithParameterList(
                    ParameterList(
                        SingletonSeparatedList(
                            Parameter(ProxyTargetParameterName.Identifier)
                                .WithType(NullableType(TypeDef.ToTypeRef())))))
                .WithBody(
                    Block(
                        SingletonList<StatementSyntax>(
                            ExpressionStatement(
                                AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression,
                                    MemberAccessExpression(
                                        SyntaxKind.SimpleMemberAccessExpression,
                                        ThisExpression(),
                                        ProxyTargetFieldName),
                                    ProxyTargetParameterName))))));
    }

    private void AddClassConstructors()
    {
        foreach (var originalCtor in TypeDef.Members.OfType<ConstructorDeclarationSyntax>()) {
            var parameters = new List<SyntaxNodeOrToken>();
            foreach (var parameter in originalCtor.ParameterList.Parameters) {
                if (parameters.Count > 0)
                    parameters.Add(Token(SyntaxKind.CommaToken));
                parameters.Add(Argument(IdentifierName(parameter.Identifier.Text)));
            }

            Constructors.Add(
                ConstructorDeclaration(Identifier(ProxyTypeName))
                    .WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
                    .WithParameterList(originalCtor.ParameterList)
                    .WithInitializer(
                        ConstructorInitializer(SyntaxKind.BaseConstructorInitializer,
                            ArgumentList(SeparatedList<ArgumentSyntax>(parameters))))
                    .WithBody(Block()));
        }
    }

    private void AddProxyMethods()
    {
        var methodIndex = 0;
        foreach (var method in GetProxyMethods()) {
            var modifiers = TokenList(
                method.DeclaredAccessibility.HasFlag(Accessibility.Protected)
                    ? Token(SyntaxKind.ProtectedKeyword)
                    : Token(SyntaxKind.PublicKeyword));
            if (!IsInterfaceProxy)
                modifiers = modifiers.Add(Token(SyntaxKind.OverrideKeyword));

            var returnType = method.ReturnType.ToTypeRef();
            var returnTypeIsVoid = returnType.IsVoid();
            var parameters = ParameterList(CommaSeparatedList(
                method.Parameters.Select(p =>
                    Parameter(Identifier(p.Name))
                        .WithType(p.Type.ToTypeRef()))));

            // __cachedMethodInfoN field 
            var cachedMethodInfoFieldName = "__cachedMethodInfo" + methodIndex;
            StaticFields.Add(
                PrivateStaticFieldDef(
                    NullableMethodInfoType,
                    Identifier(cachedMethodInfoFieldName),
                    AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression,
                        IdentifierName(cachedMethodInfoFieldName),
                        GetMethodInfoExpression(TypeDef, method, parameters))));

            // __cachedInterceptedN field 
            var cachedInterceptedFieldName = "__cachedIntercepted" + methodIndex;
            Fields.Add(CachedInterceptedFieldDef(Identifier(cachedInterceptedFieldName), returnType));

            // __cachedInterceptN field 
            if (!CachedInterceptFieldNames.TryGetValue(method.ReturnType, out var cachedInterceptFieldName)) {
                cachedInterceptFieldName = "__cachedIntercept" + methodIndex;
                CachedInterceptFieldNames.Add(method.ReturnType, cachedInterceptFieldName);
                Fields.Add(CachedInterceptFieldDef(Identifier(cachedInterceptFieldName), returnType));

                var interceptMethod = returnTypeIsVoid
                    ? (SimpleNameSyntax)ProxyInterceptMethodName
                    : ProxyInterceptGenericMethodName
                        .WithTypeArgumentList(TypeArgumentList(SingletonSeparatedList(returnType)));

                BindMethodStatements.Add(
                    ExpressionStatement(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            IdentifierName(cachedInterceptFieldName),
                            MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                InterceptorFieldName,
                                interceptMethod))));
                    ExpressionStatement(
                        AssignmentExpression(
                            SyntaxKind.SimpleAssignmentExpression,
                            IdentifierName(cachedInterceptFieldName),
                            GetMethodInfoExpression(TypeDef, method, parameters)));
            }

            var interceptedLambda = CreateInterceptedLambda(method, parameters);
            var newArgumentList = method.Parameters
                .Select(p => Argument(IdentifierName(p.Name)))
                .ToArray();

            var body = Block(
                VarStatement(InterceptedVarName.Identifier,
                    CoalesceAssignmentExpression(IdentifierName(cachedInterceptedFieldName), interceptedLambda)),
                VarStatement(InvocationVarName.Identifier,
                    CreateInvocationInstance(
                        ThisExpression(),
                        SuppressNullWarning(IdentifierName(cachedMethodInfoFieldName)),
                        NewArgumentList(newArgumentList),
                        InterceptedVarName)),
                IfStatement(
                    BinaryExpression(
                        SyntaxKind.EqualsExpression,
                        IdentifierName(cachedInterceptFieldName),
                        LiteralExpression(SyntaxKind.NullLiteralExpression)),
                    ThrowStatement<InvalidOperationException>(
                        "This proxy has no interceptor - you must call Bind method first.")),
                MaybeReturnStatement(
                    !returnTypeIsVoid,
                    InvocationExpression(
                        MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                IdentifierName(cachedInterceptFieldName),
                                IdentifierName("Invoke")))
                            .WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(InvocationVarName)))))
            );

            Methods.Add(
                MethodDeclaration(returnType, Identifier(method.Name))
                    .WithModifiers(modifiers)
                    .WithParameterList(parameters)
                    .WithBody(body));
            methodIndex++;
        }
    }

    private IEnumerable<IMethodSymbol> GetProxyMethods()
    {
        var hierarchy = IsInterfaceProxy
            ? TypeSymbol.GetAllInterfaces(true)
            : TypeSymbol.GetAllBaseTypes(true);
        WriteDebug?.Invoke($"Hierarchy: {string.Join(", ", hierarchy.Select(t => t.ToFullName()))}");
        var processedMethods = new HashSet<IMethodSymbol>(SymbolEqualityComparer.Default);
        foreach (var type in hierarchy) {
            if (type.ToTypeRef().IsObject())
                continue;

            foreach (var method in GetDeclaredProxyMethods(type)) {
                if (!processedMethods.Add(method)) {
                    WriteDebug?.Invoke("  [-] Already processed");
                    continue;
                }

                WriteDebug?.Invoke("  [+]");
                processedMethods.Add(method);
                var overriddenMethod = method.OverriddenMethod;
                while (overriddenMethod != null) {
                    processedMethods.Add(overriddenMethod);
                    overriddenMethod = overriddenMethod.OverriddenMethod;
                }
                yield return method;
            }
        }
    }

    private IEnumerable<IMethodSymbol> GetDeclaredProxyMethods(ITypeSymbol type)
    {
        foreach (var member in type.GetMembers()) {
            if (member is not IMethodSymbol method)
                continue;
            if (IsDebugOutputEnabled) {
                var returnTypeName = method.ReturnType.ToFullName();
                WriteDebug?.Invoke($"- {method.Name}({method.Parameters.Length}) -> {returnTypeName}");
            }
            if (method.MethodKind is not MethodKind.Ordinary) {
                WriteDebug?.Invoke($"  [-] Non-ordinary: {method.MethodKind}");
                continue;
            }
            if (method.IsSealed || method.IsStatic || method.IsGenericMethod) {
                WriteDebug?.Invoke("  [-] Sealed, static, or generic");
                continue;
            }
            if (!(method.DeclaredAccessibility.HasFlag(Accessibility.Public)
                    || method.DeclaredAccessibility.HasFlag(Accessibility.Protected))) {
                WriteDebug?.Invoke($"  [-] Private: {method.DeclaredAccessibility}");
                continue;
            }

            if (!IsInterfaceProxy) {
                if (method.IsAbstract || !method.IsVirtual) {
                    WriteDebug?.Invoke("  [-] Non-virtual or abstract");
                    continue;
                }
            }
            if (IsAsyncProxy) {
                var returnTypeName = method.ReturnType.ToFullName();
                if (!returnTypeName.StartsWith("System.Threading.Tasks.", StringComparison.Ordinal)) {
                    WriteDebug?.Invoke("  [-] Non-async (1)");
                    continue;
                }

                var isAsync = false;
                isAsync |= Equals(returnTypeName, "System.Threading.Tasks.Task");
                isAsync |= Equals(returnTypeName, "System.Threading.Tasks.ValueTask");
                isAsync |= returnTypeName.StartsWith("System.Threading.Tasks.Task<", StringComparison.Ordinal);
                isAsync |= returnTypeName.StartsWith("System.Threading.Tasks.ValueTask<", StringComparison.Ordinal);
                if (!isAsync) {
                    WriteDebug?.Invoke("  [-] Non-async (2)");
                    continue;
                }
            }

            // Check for [ProxyIgnore]
            var m = method;
            var mustIgnore = false;
            while (m != null) {
                if (m.GetAttributes().Any(a => Equals(a.AttributeClass?.ToFullName(), ProxyIgnoreAttributeName))) {
                    mustIgnore = true;
                    break;
                }
                m = m.OverriddenMethod;
            }
            if (mustIgnore) {
                WriteDebug?.Invoke("  [-] Has [ProxyIgnore]");
                continue;
            }

            yield return method;
        }
    }

    private static ObjectCreationExpressionSyntax CreateInvocationInstance(params ExpressionSyntax[] ctorArguments)
        => ObjectCreationExpression(IdentifierName("Invocation"))
            .WithArgumentList(
                ArgumentList(CommaSeparatedList(ctorArguments.Select(c => Argument(c)))));

    private ExpressionSyntax GetMethodInfoExpression(
        TypeDeclarationSyntax typeDeclaration,
        IMethodSymbol method,
        ParameterListSyntax parameters)
    {
        var parameterTypes = parameters.Parameters
            .Select(p => TypeOfExpression(p.Type!))
            .ToArray<ExpressionSyntax>();

        var typeFullNameDef = typeDeclaration.ToTypeRef();
        return InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                ProxyHelperTypeName,
                ProxyHelperGetMethodInfoName))
            .WithArgumentList(
                ArgumentList(
                    CommaSeparatedList(
                        Argument(
                            TypeOfExpression(typeFullNameDef)),
                        Argument(
                            LiteralExpression(SyntaxKind.StringLiteralExpression, Literal(method.Name))),
                        Argument(
                            parameterTypes.Length == 0
                            ? EmptyArrayExpression<Type>()
                            : ImplicitArrayCreationExpression(parameterTypes))
                    )));
    }

    private FieldDeclarationSyntax CachedInterceptedFieldDef(SyntaxToken name, TypeSyntax returnTypeDef)
    {
        TypeSyntax fieldTypeDef;
        if (!returnTypeDef.IsVoid()) {
            fieldTypeDef = GenericName(Identifier("global::System.Func"))
                .WithTypeArgumentList(
                    TypeArgumentList(CommaSeparatedList(ArgumentListTypeName, returnTypeDef)));
        }
        else {
            fieldTypeDef = GenericName(Identifier("global::System.Action"))
                .WithTypeArgumentList(
                    TypeArgumentList(SingletonSeparatedList<TypeSyntax>(ArgumentListTypeName)));
        }
        return PrivateFieldDef(NullableType(fieldTypeDef), name);
    }

    private FieldDeclarationSyntax CachedInterceptFieldDef(SyntaxToken name, TypeSyntax returnTypeDef)
    {
        TypeSyntax fieldTypeDef;
        if (!returnTypeDef.IsVoid()) {
            fieldTypeDef = GenericName(Identifier("global::System.Func"))
                .WithTypeArgumentList(
                    TypeArgumentList(CommaSeparatedList(InvocationTypeName, returnTypeDef)));
        }
        else {
            fieldTypeDef = GenericName(Identifier("global::System.Action"))
                .WithTypeArgumentList(
                    TypeArgumentList(SingletonSeparatedList<TypeSyntax>(InvocationTypeName)));
        }
        return PrivateFieldDef(NullableType(fieldTypeDef), name);
    }

    private SimpleLambdaExpressionSyntax CreateInterceptedLambda(IMethodSymbol method, ParameterListSyntax parameters)
    {
        var typedArgsVarGenericArguments = parameters.Parameters.Select(p => p.Type!).ToArray();

        var typeArgsVariableType =
                typedArgsVarGenericArguments.Length == 0
                ? (NameSyntax) ArgumentListTypeName
                : ArgumentListGenericTypeName.WithTypeArgumentList(
                    TypeArgumentList(CommaSeparatedList(typedArgsVarGenericArguments)));

        var args = IdentifierName("args");
        var typedArgs = IdentifierName("typedArgs");
        var proxyTargetCallArguments = new List<ArgumentSyntax>();
        for (var i = 0; i < parameters.Parameters.Count; i++) {
            var argumentList = IdentifierName("Item" + i);
            proxyTargetCallArguments.Add(Argument(
                MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    typedArgs,
                    argumentList)));
        }

        var baseRef = IsInterfaceProxy
            ? SuppressNullWarning(ProxyTargetFieldName)
            : (ExpressionSyntax) BaseExpression();
        var baseInvocation = InvocationExpression(
            MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                baseRef,
                IdentifierName(method.Name)),
            ArgumentList(CommaSeparatedList(proxyTargetCallArguments))
        );

        var returnTypeRef = method.ReturnType.ToTypeRef();
        var baseInvocationBlock = Block(
            VarStatement(typedArgs.Identifier, CastExpression(typeArgsVariableType, args)),
            MaybeReturnStatement(
                !returnTypeRef.IsVoid(),
                baseInvocation));

        return SimpleLambdaExpression(Parameter(args.Identifier))
            .WithBlock(baseInvocationBlock);
    }

    private InvocationExpressionSyntax NewArgumentList(IEnumerable<ArgumentSyntax> newArgumentListParams)
        => InvocationExpression(
                MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    ArgumentListTypeName,
                    ArgumentListNewMethodName))
            .WithArgumentList(
                ArgumentList(CommaSeparatedList(newArgumentListParams)));

    private void AddProxyInterfaceImplementation()
    {
        Fields.Add(
            PrivateFieldDef(NullableType(InterceptorTypeName), InterceptorFieldName.Identifier));

        var interceptorGetterDef = Block(
            IfStatement(
                BinaryExpression(
                    SyntaxKind.EqualsExpression,
                    InterceptorFieldName,
                    LiteralExpression(SyntaxKind.NullLiteralExpression)),
                ThrowStatement<InvalidOperationException>(
                    "This proxy has no interceptor - you must call Bind method first.")),
            ReturnStatement(InterceptorFieldName));

        Properties.Add(
            PropertyDeclaration(InterceptorTypeName, InterceptorPropertyName.Identifier)
                .WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier(ProxyInterfaceTypeName))
                .WithAccessorList(
                    AccessorList(
                        SingletonList(
                            AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithBody(interceptorGetterDef)))));

        var bindMethodBody = Block(
            IfStatement(
                BinaryExpression(
                    SyntaxKind.NotEqualsExpression,
                    InterceptorFieldName,
                    LiteralExpression(
                        SyntaxKind.NullLiteralExpression)),
                ThrowStatement<InvalidOperationException>("Interceptor is already bound.")),
            ExpressionStatement(
                AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    InterceptorFieldName,
                    BinaryExpression(
                        SyntaxKind.CoalesceExpression,
                        InterceptorParameterName,
                        ThrowExpression<ArgumentNullException>(InterceptorParameterName.Identifier.Text)))));
        bindMethodBody = bindMethodBody.AddStatements(BindMethodStatements.ToArray());

        Methods.Add(
            MethodDeclaration(PredefinedType(Token(SyntaxKind.VoidKeyword)), ProxyInterfaceBindMethodName.Identifier)
                .WithExplicitInterfaceSpecifier(ExplicitInterfaceSpecifier(ProxyInterfaceTypeName))
                .WithParameterList(
                    ParameterList(SingletonSeparatedList(
                        Parameter(InterceptorParameterName.Identifier)
                            .WithType(InterceptorTypeName))))
                .WithBody(bindMethodBody));
    }
}

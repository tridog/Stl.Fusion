using Stl.Interception;
using Stl.Reflection;

namespace Stl.Tests.Generators;

public class ProxyTest : TestBase
{
    public ProxyTest(ITestOutputHelper @out) : base(@out) { }

    [Theory]
    [InlineData(1000_000)]
    [InlineData(25_000_000)]
    public void BenchmarkAll(int baseOpCount)
    {
        var interceptor = new Interceptor();
        var noProxy = new ClassProxy();
        var altProxy = new AltClassProxy(interceptor);
        var classProxy = (ClassProxy)typeof(ClassProxy).GetProxyType()!.CreateInstance();
        interceptor.BindTo(classProxy);
        var interfaceProxy = (IInterfaceProxy)typeof(IInterfaceProxy).GetProxyType()!.CreateInstance(noProxy);
        interceptor.BindTo(interfaceProxy);

        RunOne("NoProxy.VoidMethod", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                noProxy.VoidMethod();
            return 0;
        });
        RunOne("NoProxy.Method0", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                noProxy.Method0();
            return 0;
        });
        RunOne("NoProxy.Method1", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                noProxy.Method1(default);
            return 0;
        });
        RunOne("NoProxy.Method2", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                noProxy.Method2(0, default);
            return 0;
        });

        RunOne("ClassProxy.VoidMethod", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                classProxy.VoidMethod();
            return 0;
        });
        RunOne("ClassProxy.Method0", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                classProxy.Method0();
            return 0;
        });
        RunOne("ClassProxy.Method1", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                classProxy.Method1(default);
            return 0;
        });
        RunOne("ClassProxy.Method2", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                classProxy.Method2(0, default);
            return 0;
        });
        RunOne("AltClassProxy.Method2", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                altProxy.Method2(0, default);
            return 0;
        });

        RunOne("InterfaceProxy.VoidMethod", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                interfaceProxy.VoidMethod();
            return 0;
        });
        RunOne("InterfaceProxy.Method0", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                interfaceProxy.Method0();
            return 0;
        });
        RunOne("InterfaceProxy.Method1", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                interfaceProxy.Method1(default);
            return 0;
        });
        RunOne("InterfaceProxy.Method2", baseOpCount, opCount => {
            for (; opCount > 0; opCount--)
                interfaceProxy.Method2(0, default);
            return 0;
        });
    }

    void RunOne<T>(string title, int opCount, Func<int, T> action)
    {
        action(Math.Min(1, opCount / 10));
        var sw = Stopwatch.StartNew();
        _ = action(opCount);
        sw.Stop();
        var rate = opCount / sw.Elapsed.TotalSeconds;
        Out.WriteLine($"{title} ({opCount}): {rate:N3} ops/s");
    }
}

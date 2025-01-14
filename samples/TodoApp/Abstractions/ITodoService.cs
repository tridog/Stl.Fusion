using Stl.Fusion.Blazor;
using Stl.Fusion.Extensions;

namespace Templates.TodoApp.Abstractions;

[ParameterComparer(typeof(ByValueParameterComparer))]
public sealed record Todo(string Id, string Title, bool IsDone = false)
{
    public Todo() : this("", "") { }
}

public sealed record TodoSummary(int Count, int DoneCount)
{
    public TodoSummary() : this(0, 0) { }
}

public sealed record AddOrUpdateTodoCommand(Session Session, Todo Item) : ISessionCommand<Todo>
{
    // Newtonsoft.Json needs this constructor to deserialize this record
    public AddOrUpdateTodoCommand() : this(Session.Null, default!) { }
}

public sealed record RemoveTodoCommand(Session Session, string Id) : ISessionCommand<Unit>
{
    // Newtonsoft.Json needs this constructor to deserialize this record
    public RemoveTodoCommand() : this(Session.Null, "") { }
}

public interface ITodoService : IComputeService
{
    // Commands
    [CommandHandler]
    Task<Todo> AddOrUpdate(AddOrUpdateTodoCommand command, CancellationToken cancellationToken = default);
    [CommandHandler]
    Task Remove(RemoveTodoCommand command, CancellationToken cancellationToken = default);

    // Queries
    [ComputeMethod]
    Task<Todo?> Get(Session session, string id, CancellationToken cancellationToken = default);
    [ComputeMethod]
    Task<Todo[]> List(Session session, PageRef<string> pageRef, CancellationToken cancellationToken = default);
    [ComputeMethod(InvalidationDelay = 1)]
    Task<TodoSummary> GetSummary(Session session, CancellationToken cancellationToken = default);
}

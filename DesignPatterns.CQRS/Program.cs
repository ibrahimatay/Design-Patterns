using System.Collections.Concurrent;

namespace DesignPatterns.CQRS;

// CQRS Bus (Dispatcher)
public interface IEventBus {
    Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
}

public class EventBus : IEventBus {
    private readonly ConcurrentDictionary<Type, Func<object, Task>> _commands = new();
    private readonly ConcurrentDictionary<Type, Func<object, Task<object>>> _queries = new();

    public void RegisterCommand<TCommand>(Func<TCommand, Task> handler) where TCommand : ICommand {
        _commands[typeof(TCommand)] = command => handler((TCommand)command);
    }

    public void RegisterQuery<TQuery, TResult>(Func<TQuery, Task<TResult>> handler) where TQuery : IQuery<TResult> {
        _queries[typeof(TQuery)] = async query => await handler((TQuery)query);
    }

    public async Task Send<TCommand>(TCommand command) where TCommand : ICommand {
        if (_commands.TryGetValue(typeof(TCommand), out var handler)) {
            await handler(command);
        }
        else {
            throw new InvalidOperationException($"No handler registered for {typeof(TCommand).Name}");
        }
    }

    public async Task<TResult> Query<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult> {
        if (_queries.TryGetValue(typeof(TQuery), out var handler)) {
            return (TResult)await handler(query);
        }
        throw new InvalidOperationException($"No handler registered for {typeof(TQuery).Name}");
    }
}

// Command and Query interfaces
public interface ICommand { }
public interface IQuery<TResult> { }

// Data Store
public class InMemoryStore {
    private readonly ConcurrentDictionary<Guid, string> _items = new();
    
    public void Add(Guid id, string value) {
        _items[id] = value;
    }
    
    public string? Get(Guid id) {
        _items.TryGetValue(id, out var value);
        return value;
    }
    
    public List<string> GetAll() => _items.Values.ToList();
}

// Commands
public class AddItemCommand(Guid id, string value) : ICommand
{
    public Guid Id { get; } = id;
    public string Value { get; } = value;
}

public class AddItemHandler(InMemoryStore store)
{
    public Task Handle(AddItemCommand command) {
        store.Add(command.Id, command.Value);
        return Task.CompletedTask;
    }
}

// Queries
public class GetItemQuery(Guid id) : IQuery<string?>
{
    public Guid Id { get; } = id;
}

public class GetItemHandler(InMemoryStore store)
{
    public Task<string?> Handle(GetItemQuery query) => Task.FromResult(store.Get(query.Id));
}

// Test Case
public static class Program {
    public static async Task Main() {
        var store = new InMemoryStore();
        var bus = new EventBus();
        
        var addItemHandler = new AddItemHandler(store);
        var getItemHandler = new GetItemHandler(store);

        bus.RegisterCommand<AddItemCommand>(addItemHandler.Handle);
        bus.RegisterQuery<GetItemQuery, string?>(getItemHandler.Handle);
        
        var id = Guid.NewGuid();
        await bus.Send(new AddItemCommand(id, "CQRS Test Item"));
        
        var result = await bus.Query<GetItemQuery, string?>(new GetItemQuery(id));
        Console.WriteLine($"Item: {result}");
    }
}
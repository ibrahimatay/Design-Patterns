namespace DesignPatterns.Pipeline;

public record Message(long Id, string Content);

public record Messages(List<Message> Items);

public interface IStage<T>
{
    T Execute(T input);
}

public class CreateMessagesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        var messages = new List<Message>
        {
            new Message(1, "Hi Alice"),
            new Message(1, "Hi Alice"),
            new Message(2, "Hello Bob"),
            new Message(3, "How are you, Alice"),
            new Message(4, "I am doing good."),
            new Message(1, "Hi Alice")
        };

        return new Messages(messages);
    }
}

public class OutputMessagesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        input.Items.ForEach(item => Console.WriteLine(item.Content));
        return input;
    }
}

public class RemoveDuplicatesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        var uniqueMessages = input.Items.Distinct().ToList();
        return new Messages(uniqueMessages);
    }
}

public class SortMessagesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        var sortedMessages = input.Items.OrderBy(m => m.Id).ToList();
        return new Messages(sortedMessages);
    }
}

public interface IPipeline<T>
{
    void Add(IStage<T> stage);
    void Execute();
}

public class MessagesPipeline : IPipeline<Messages>
{
    private readonly List<IStage<Messages>> _stages = new();
    public void Add(IStage<Messages> stage) => _stages.Add(stage);
    public void Execute()
    {
        Messages input = null, output;

        foreach (var stage in _stages)
        {
            output = stage.Execute(input);
            input = output;
        }
    }
}

class App
{
    public static void Main()
    {
        IPipeline<Messages> pipeline = new MessagesPipeline();
        pipeline.Add(new CreateMessagesStage());
        pipeline.Add(new RemoveDuplicatesStage());
        pipeline.Add(new SortMessagesStage());
        pipeline.Add(new OutputMessagesStage());

        pipeline.Execute();
    }
}
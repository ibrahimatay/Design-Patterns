using DesignPatterns.Pipeline.Model;

namespace DesignPatterns.Pipeline.Stage;

public class OutputMessagesStage : IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        input.MessageList.ForEach(Console.WriteLine);
        
        return input;
    }
}
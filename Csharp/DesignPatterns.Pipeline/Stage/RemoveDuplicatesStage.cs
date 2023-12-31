using DesignPatterns.Pipeline.Model;

namespace DesignPatterns.Pipeline.Stage;

public class RemoveDuplicatesStage:IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        List<Message> messages = new List<Message>();
        foreach (var message in input.MessageList)
        {
            if (!messages.Contains(message))
            {
                messages.Add(message);
            }
        }
        
        return new Messages(messages);
    }
}
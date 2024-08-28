using DesignPatterns.Pipeline.Model;

namespace DesignPatterns.Pipeline.Stage;

public class CreateMessagesStage: IStage<Messages>
{
    public Messages Execute(Messages input)
    {
        List<Message> messages = new();
        messages.Add(new Message(1, "Hi Alice"));
        messages.Add(new Message(1, "Hi Alice"));
        messages.Add(new Message(2, "Hello Bob"));
        messages.Add(new Message(3, "How are you, Alice"));
        messages.Add(new Message(4, "I am doing good."));
        messages.Add(new Message(1, "Hi Alice"));

        return new Messages(messages);
    }
}
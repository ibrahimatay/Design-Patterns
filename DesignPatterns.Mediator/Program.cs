namespace DesignPatterns.Mediator;

public interface IMessenger
{
    void Receiver(string message);
}

public interface IChat
{
    void SendMessage(IMessenger receiver, string message);
    void AddMessenger(IMessenger messenger);
}

public class AliceMessenger : IMessenger
{
    public void Receiver(string message)=>Console.WriteLine($"received the message: {message}");
}

public class BobMessenger : IMessenger
{
    public void Receiver(string message)=>Console.WriteLine($"received the message: {message}");
}

public class AnonymousChat : IChat
{
    private readonly List<IMessenger> _messengers = new();

    public void SendMessage(IMessenger receiver, string message)
    {
        var messenger = _messengers.FirstOrDefault(x => x == receiver);
        if (messenger == null) return;

        messenger.Receiver(message);
    }

    public void AddMessenger(IMessenger messenger) => _messengers.Add(messenger);
}

class App
{
    public static void Main()
    {
        IChat chat = new AnonymousChat();

        IMessenger bobMessenger = new BobMessenger();
        IMessenger aliceMessenger = new AliceMessenger();

        chat.AddMessenger(bobMessenger);
        chat.AddMessenger(aliceMessenger);

        chat.SendMessage(aliceMessenger, "Hello");
        chat.SendMessage(bobMessenger, "How are you, Alice");
    }
}
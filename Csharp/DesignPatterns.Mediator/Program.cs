IChat chat = new AnonymousChat();

IMessenger bobMessenger = new BobMessenger();
IMessenger aliceMessenger = new AliceMessenger();

chat.AddMessenger(bobMessenger);
chat.AddMessenger(aliceMessenger);

chat.SendMessage(aliceMessenger, "Hello");
chat.SendMessage(bobMessenger, "How are you, Alice");

interface IMessenger
{
    void Receiver(string message);
}

interface IChat
{
    void SendMessage(IMessenger receiver, string message);
    void AddMessenger(IMessenger messenger);
}

class AliceMessenger : IMessenger
{
    public void Receiver(string message) => Console.WriteLine($"received the message: {message}");
}

class BobMessenger : IMessenger
{
    public void Receiver(string message) => Console.WriteLine($"received the message: {message}");
}

class AnonymousChat : IChat
{
    private readonly List<IMessenger> _messengers = new();

    public void SendMessage(IMessenger receiver, string message)
    {
        if (!string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        receiver.Receiver(message);
    }

    public void AddMessenger(IMessenger messenger) => _messengers.Add(messenger);
}
// transactional-outbox-pattern
// https://github.com/mspnp/transactional-outbox-pattern

// Pattern: Transactional outbox
// https://microservices.io/patterns/data/transactional-outbox.html

namespace DesignPatterns.Outbox;

class Order
{
    public Guid Id { get; set; }
    public string Description { get; set; }
}

class OutboxMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Payload { get; set; }
    public bool Processed { get; set; }
}

class Database
{
    List<OutboxMessage> _outboxMessages = [];
    
    public void SaveOrder(Order order)
    {
        Console.WriteLine($"Order {order.Id} saved to database.");
        _outboxMessages.Add(new OutboxMessage { Payload = $"Order {order.Id} created." });
    }

    public List<OutboxMessage> GetUnprocessedMessages() 
        => _outboxMessages.Where(m => !m.Processed).ToList();

    public void MarkMessageAsProcessed(Guid messageId)
    {
        var message = _outboxMessages.FirstOrDefault(m => m.Id == messageId);
        if (message != null) message.Processed = true;
    }
}

class MessageQueue
{
    public void SendMessage(string message) 
        => Console.WriteLine($"Message sent to queue: {message}");
}

class OutboxProcessor(Database database, MessageQueue messageQueue)
{
    public void ProcessOutbox()
    {
        while (true)
        {
            var messages = database.GetUnprocessedMessages();
            foreach (var message in messages)
            {
                messageQueue.SendMessage(message.Payload);
                database.MarkMessageAsProcessed(message.Id);
                Console.WriteLine($"Message {message.Id} processed.");
            }
            
            Thread.Sleep(2000); // Wait time for simulation
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting Outbox Pattern Simulation...");
        Database database = new Database();
        MessageQueue messageQueue = new MessageQueue();
        
        // 1. Record is added to the Outbox table when processing an order
        Console.WriteLine("Processing an order...");
        var order = new Order { Id = Guid.NewGuid(), Description = "New Order" };
        database.SaveOrder(order);

        // 2. A background process processes the messages in the outbox
        Task.Run(() => new OutboxProcessor(database, messageQueue).ProcessOutbox());

        Thread.Sleep(5000); // Wait time for simulation
        Console.WriteLine("Simulation completed.");
    }
}
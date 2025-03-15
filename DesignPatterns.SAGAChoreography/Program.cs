// Sagas - Hector Garcia-Molina & Kenneth Salem (1987)
// in docs folder

// Saga distributed transactions pattern
// https://learn.microsoft.com/en-us/azure/architecture/patterns/saga

// Pattern: Saga
// https://microservices.io/patterns/data/saga.html

using System.Collections.Concurrent;

namespace DesignPatterns.SagaChoreography;

public record OrderCreatedEvent(Guid OrderId, decimal Amount);
public record PaymentProcessedEvent(Guid OrderId, bool Success);
public record StockCheckedEvent(Guid OrderId, bool InStock);
public record OrderCompletedEvent(Guid OrderId);
public record OrderCancelledEvent(Guid OrderId, string Reason);

class EventBus
{
    readonly ConcurrentDictionary<Type, List<Action<object>>> _subscribers = new();

    public void Subscribe<T>(Action<T> action)
    {
        if (!_subscribers.ContainsKey(typeof(T)))
        {
            _subscribers[typeof(T)] = [];
        }

        _subscribers[typeof(T)].Add(obj => action((T)obj));
    }

    public void Publish<T>(T eventMessage)
    {
        if (!_subscribers.ContainsKey(typeof(T))) return;

        foreach (var action in _subscribers[typeof(T)])
        {
            action(eventMessage);
        }
    }
}

class OrderService(EventBus eventBus)
{
    public void CreateOrder(Guid orderId, decimal amount)
    {
        Console.WriteLine($"[OrderService] Order created: {orderId}");
        eventBus.Publish(new OrderCreatedEvent(orderId, amount));
    }
}

class PaymentService
{
    private readonly EventBus _eventBus;

    public PaymentService(EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.Subscribe<OrderCreatedEvent>(ProcessPayment);
    }

    private void ProcessPayment(OrderCreatedEvent orderEvent)
    {
        Console.WriteLine($"[PaymentService] Processing payment... Order ID: {orderEvent.OrderId}");

        bool paymentSuccess = orderEvent.Amount < 1000; // Orders above 1000 fail intentionally

        if (paymentSuccess)
        {
            Console.WriteLine($"[PaymentService] Payment successful! Order ID: {orderEvent.OrderId}");
            _eventBus.Publish(new PaymentProcessedEvent(orderEvent.OrderId, true));
        }
        else
        {
            Console.WriteLine($"[PaymentService] Payment failed! Order ID: {orderEvent.OrderId}");
            _eventBus.Publish(new OrderCancelledEvent(orderEvent.OrderId, "Payment failed"));
        }
    }
}

class StockService
{
    private readonly EventBus _eventBus;

    public StockService(EventBus eventBus)
    {
        _eventBus = eventBus;
        _eventBus.Subscribe<PaymentProcessedEvent>(CheckStock);
    }

    private void CheckStock(PaymentProcessedEvent paymentEvent)
    {
        if (!paymentEvent.Success) return;

        Console.WriteLine($"[StockService] Checking stock... Order ID: {paymentEvent.OrderId}");

        bool inStock = new Random().Next(0, 2) == 1; // Random stock availability

        if (inStock)
        {
            Console.WriteLine($"[StockService] Stock available! Order ID: {paymentEvent.OrderId}");
            _eventBus.Publish(new StockCheckedEvent(paymentEvent.OrderId, true));
        }
        else
        {
            Console.WriteLine($"[StockService] Stock insufficient! Order ID: {paymentEvent.OrderId}");
            _eventBus.Publish(new OrderCancelledEvent(paymentEvent.OrderId, "Stock unavailable"));
        }
    }
}

class OrderCompletionService
{
    public OrderCompletionService(EventBus eventBus)
    {
        eventBus.Subscribe<StockCheckedEvent>(CompleteOrder);
        eventBus.Subscribe<OrderCancelledEvent>(CancelOrder);
    }

    private void CompleteOrder(StockCheckedEvent stockEvent)
    {
        Console.WriteLine($"[OrderCompletionService] Order completed! Order ID: {stockEvent.OrderId}");
    }

    private void CancelOrder(OrderCancelledEvent cancelEvent)
    {
        Console.WriteLine($"[OrderCompletionService] Order cancelled: {cancelEvent.Reason} Order ID: {cancelEvent.OrderId}");
    }
}

class Program
{
    static void Main()
    {
        var eventBus = new EventBus();

        var orderService = new OrderService(eventBus);
        var paymentService = new PaymentService(eventBus);
        var stockService = new StockService(eventBus);
        var orderCompletionService = new OrderCompletionService(eventBus);

        var orderId = Guid.NewGuid();
        decimal orderAmount = new Random().Next(500, 1500); // Random order amount

        orderService.CreateOrder(orderId, orderAmount);
    }
}
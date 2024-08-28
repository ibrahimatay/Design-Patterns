var maxCustomerCountHandle = new MaxCustomerCountHandler();
var dueDateHandle = new DueDateHandler();
var startDateHandle = new StartDateHandle();
var creditBalanceHandle = new CreditBalanceHandle();

maxCustomerCountHandle
    .setNext(dueDateHandle)
    .setNext(startDateHandle)
    .setNext(creditBalanceHandle);

List<String> customers = new List<string>()
{
    "Customer A", "Customer B", "Customer C", "Customer D"
};

var processor = new Processor(maxCustomerCountHandle);
processor.Start(customers);


interface Handler
{
    Handler setNext(Handler? handler);
    Object handle(String message);
}

abstract class AbstractHandler : Handler
{
    private Handler _handler;

    public Handler setNext(Handler handler)
    {
        return _handler = handler;
    }

    public virtual Object handle(String message)
    {
        if (_handler == null) return null;
        return _handler.handle(message);
    }
}

sealed class MaxCustomerCountHandler : AbstractHandler
{
    public override object handle(string message)
    {
        Console.WriteLine($"Max customer count validation handled for {message}");
        return base.handle(message);
    }
}

sealed class DueDateHandler : AbstractHandler
{
    public override object handle(string message)
    {
        Console.WriteLine($"End date validation handled for {message}");
        return base.handle(message);
    }
}

sealed class StartDateHandle : AbstractHandler
{
    public override object handle(string message)
    {
        Console.WriteLine($"Start date validation handled for {message}");
        return base.handle(message);
    }
}

sealed class CreditBalanceHandle : AbstractHandler
{
    public override object handle(string message)
    {
        Console.WriteLine($"Credit balance handled for {message}");
        return base.handle(message);
    }
}

sealed class Processor
{
    private readonly AbstractHandler _handler;

    public Processor(AbstractHandler handler)
    {
        _handler = handler;
    }

    public void Start(List<String> messages)
    {
        foreach (string message in messages)
        {
            _handler.handle(message);
        }
    }
}
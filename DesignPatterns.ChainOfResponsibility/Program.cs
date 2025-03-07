namespace DesignPatterns.ChainOfResponsibility;

interface IHandler {
    IHandler SetNext(IHandler handler);
    object Handle(string message);
}

abstract class AbstractHandler : IHandler 
{
    private IHandler _handler;
    public IHandler SetNext(IHandler handler) => _handler = handler;

    public virtual object Handle(string message) 
        => _handler == null ? null : _handler.Handle(message);
}

sealed class MaxCustomerCountHandler : AbstractHandler {
    public override object Handle(string message)
    {
        Console.WriteLine($"Max customer count validation handled for {message}");
        return base.Handle(message);
    }
}

sealed class DueDateHandler : AbstractHandler {
    public override object Handle(string message)
    {
        Console.WriteLine($"Due date validation handled for {message}");
        return base.Handle(message);
    }
}

sealed class StartDateHandle : AbstractHandler {
    public override object Handle(string message)
    {
        Console.WriteLine($"Start date validation handled for {message}");
        return base.Handle(message);
    }
}

sealed class CreditBalanceHandle : AbstractHandler {
    public override object Handle(string message)
    {
        Console.WriteLine($"Credit balance validation handled for {message}");
        return base.Handle(message);
    }
}

sealed class Processor(AbstractHandler handler)
{
    public void Start(List<string> messages) 
        => messages.ForEach(message=> handler.Handle(message));
}

class App
{
    public static void Main(string[] args)
    {
        var maxCustomerCountHandle = new MaxCustomerCountHandler();
        var dueDateHandle = new DueDateHandler();
        var startDateHandle = new StartDateHandle();
        var creditBalanceHandle = new CreditBalanceHandle();
        
        maxCustomerCountHandle
            .SetNext(dueDateHandle)
            .SetNext(startDateHandle)
            .SetNext(creditBalanceHandle);
        
        List<string> customers = ["Customer A","Customer B","Customer C","Customer D"];
        
        var processor = new Processor(maxCustomerCountHandle);
        processor.Start(customers);
    }
}
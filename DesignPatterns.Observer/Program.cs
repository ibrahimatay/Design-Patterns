namespace DesignPatterns.Observer;

public enum ChangeType
{
    Add, Update, Delete
}

public record Subscriber(string Name)
{
    public void Update(Subscriber subscriber, Page page, ChangeType changeType) =>
        Console.WriteLine($"Subscriber Name:{{{subscriber.Name}}} Change Type:{{{changeType}}} Page Name:{{{page.PageName}}}");
}

public class Page
{
    private string _name;
    readonly List<Subscriber> _subscribers = new();
    
    public string PageName => _name;

    public void UpdateToPage(string pageName)
    {
        _name = pageName;
        Notify(ChangeType.Update);
    }

    public void AddToPage(string pageName)
    {
        _name = pageName;
        Notify(ChangeType.Add);
    }

    public void DeleteToPage() => Notify(ChangeType.Delete);

    public void Subscribe(Subscriber subscriber) => _subscribers.Add(subscriber);

    private void Notify(ChangeType changeType) =>
        _subscribers.ForEach(subscriber=> subscriber.Update(subscriber, this, changeType));
}

class App
{
    public static void Main()
    {
        var page = new Page();
        page.Subscribe(new Subscriber("Ibrahim"));
        page.Subscribe(new Subscriber("Tom"));
        page.Subscribe(new Subscriber("Carton"));

        page.AddToPage("test1");
        page.UpdateToPage("test2");
        page.DeleteToPage();
    }
}
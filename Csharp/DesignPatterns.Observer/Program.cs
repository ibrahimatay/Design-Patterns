
Page page = new Page();
page.Subscribe(new Subscriber("Ibrahim"));
page.Subscribe(new Subscriber("Tom"));
page.Subscribe(new Subscriber("Carton"));

page.Add("test1");
page.Update("test2");
page.Delete();


enum ChangeType
{
    Add = 0, Update = 1, Delete = 2
}

record Subscriber(string name)
{
    public void Update(Subscriber subscriber, Page page, ChangeType changeType)
        => Console.WriteLine($"Subscriber Name:{subscriber.name} Change Type:{changeType} Page Name:{page.GetName()}");
}

class Page
{
    private string? name;
    private readonly List<Subscriber> subscribers = new();


    public string GetName() => name;

    public void Update(String pageName)
    {
        this.name = pageName;
        Notify(ChangeType.Update);
    }

    public void Add(String pageName)
    {
        this.name = pageName;
        Notify(ChangeType.Add);
    }

    public void Delete() => Notify(ChangeType.Delete);

    public void Subscribe(Subscriber subscriber) => this.subscribers.Add(subscriber);

    private void Notify(ChangeType changeType) => subscribers.ForEach(subscriber => subscriber.Update(subscriber, this, changeType));
}

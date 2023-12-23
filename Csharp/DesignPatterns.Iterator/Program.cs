Item item1 = new Item("Item 1");
Item item2 = new Item("Item 2");
Item item3 = new Item("Item 3");
Item item4 = new Item("Item 4");

IAggregate concreteAggregate = new ConcreteAggregate();
IIterator iterator = concreteAggregate.CreateIterator();

iterator.Add(item1);
iterator.Add(item2);
iterator.Add(item3);
iterator.Add(item4);

while (iterator.HasNext())
{
    var item = iterator.Next();
    Console.WriteLine(item);
}

record Item(String Name)
{
}

interface IIterator
{
    bool HasNext();
    Item Next();
    void Add(Item item);
    bool Remove();
}

class ListIterator : IIterator
{
    private readonly List<Item> _items = new();
    private int _index = 0;

    public bool HasNext() => _index < _items.Count;

    public Item Next()
    {
        Item currentItem = _items[_index];

        _index++;
        return currentItem;
    }

    public void Add(Item item) => _items.Add(item);
    public bool Remove() => _items.Remove(_items[_index]);
}

interface IAggregate
{
    IIterator CreateIterator();
}

class ConcreteAggregate : IAggregate
{
    public IIterator CreateIterator() => new ListIterator();
}
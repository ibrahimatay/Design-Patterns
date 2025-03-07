namespace DesignPatterns.Iterator;

public record Item(string Name);

public interface IIterator
{
    bool HasNext();
    Item Next();
    void Add(Item item);
    bool Remove();
}

class ListIterator : IIterator
{
    private readonly List<Item> _items = [];
    private int _index = 0;

    public bool HasNext()
    {
        return _index < _items.Count;
    }

    public Item Next()
    {
        var currentItem = _items[_index];
        _index++;
        return currentItem;
    }

    public void Add(Item item)=>_items.Add(item);

    public bool Remove()
    {
        if (_index >= _items.Count)
            return false;
            
        _items.RemoveAt(_index);
        return true;
    }
}

public interface IAggregate
{
    IIterator CreateIterator();
}

public class ConcreteAggregate : IAggregate
{
    public IIterator CreateIterator() => new ListIterator();

}

class App
{
    public static void Main()
    {
        IAggregate concreteAggregate = new ConcreteAggregate();
        IIterator iterator = concreteAggregate.CreateIterator();

        var items = new List<Item>()
        {
            new("Item 1"), new("Item 2"), new("Item 3"), new("Item 4")
        };
        
        items.ForEach(item => iterator.Add(item));
        
        while (iterator.HasNext())
        {
            var item = iterator.Next();
            Console.WriteLine(item);
        }
    }
}
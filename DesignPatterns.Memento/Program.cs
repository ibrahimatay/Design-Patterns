namespace DesignPatterns.Memento;

public record Memento<T>(T State);

public class Originator<T>
{
    private T _state;

    public T GetState() => _state;

    public void SetState(T state) => _state = state;

    public Memento<T> Redo() => new(_state);

    public void Undo(Memento<T> memento) => _state = memento.State;
}

public class CareTaker<T>
{
    private Memento<T> _memento;

    public Memento<T> GetMemento() => _memento;

    public void SetMemento(Memento<T> memento)=>_memento = memento;
}

class App
{
    public static void Main()
    {
        Originator<int> originator = new();
        originator.SetState(1);

        CareTaker<int> careTaker = new();
        careTaker.SetMemento(originator.Redo());

        Console.WriteLine(originator.GetState());

        originator.SetState(2);
        Console.WriteLine(originator.GetState());

        originator.Undo(careTaker.GetMemento());

        Console.WriteLine(originator.GetState());
    }
}
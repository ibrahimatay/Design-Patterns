Originator<int> originator = new Originator<int>();
originator.SetState(1);

CareTaker<int> careTaker = new CareTaker<int>();
careTaker.SetMemento(originator.Redo());

Console.WriteLine(originator.GetState());

originator.SetState(2);
Console.WriteLine(originator.GetState());


originator.Undo(careTaker.GetMemento());
Console.WriteLine(originator.GetState());


record Memento<T>(T state)
{
}

class Originator<T>
{
    private T _state { get; set; }

    public T GetState()
    {
        return _state;
    }

    public void SetState(T state)
    {
        this._state = state;
    }

    public Memento<T> Redo()
    {
        return new Memento<T>(_state);
    }

    public void Undo(Memento<T> memento)
    {
        this._state = memento.state;
    }
}

class CareTaker<T>
{
    private Memento<T> _memento;

    public Memento<T> GetMemento()
    {
        return _memento;
    }

    public void SetMemento(Memento<T> memento)
    {
        this._memento = memento;
    }
}
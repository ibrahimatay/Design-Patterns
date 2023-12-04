
Console.WriteLine("Human Skills:");
Human human = new(new Living());
human.Describe();

Console.WriteLine("----------------");

Console.WriteLine("Bird Skills:");
Bird bird = new(new Living());
bird.Describe();

interface IAnimal
{
    void Describe();
}

sealed class Living : IAnimal
{
    public void Describe()
    {
        Console.WriteLine("I am animal");
    }
}

abstract class AnimalDecorator : IAnimal
{
    readonly IAnimal _animal;

    protected AnimalDecorator(IAnimal animal)
    {
        this._animal = animal;
    }

    public virtual void Describe()
    {
        _animal.Describe();
    }
}

class Bird : AnimalDecorator
{
    public Bird(IAnimal animal) : base(animal)
    {
    }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("I can fly");
        Console.WriteLine("I can sing");
    }
}

class Human : AnimalDecorator
{
    public Human(IAnimal animal) : base(animal)
    {
    }

    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("I can write");
        Console.WriteLine("I can walk");
    }
}
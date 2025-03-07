namespace DesignPatterns.Decorator;

interface IAnimal 
{
    void Describe();
}

sealed class Living : IAnimal {
    public void Describe() => Console.WriteLine("I am animal");
}

abstract class AnimalDecorator(IAnimal animal) : IAnimal
{
    public virtual void Describe()=>animal.Describe();
}

class Bird(IAnimal animal) : AnimalDecorator(animal)
{
    public override void Describe()
    {    
        Console.WriteLine("I can fly");
        Console.WriteLine("I can sing");
    }
}

class Human(IAnimal animal) : AnimalDecorator(animal)
{
    public override void Describe()
    {
        base.Describe();
        Console.WriteLine("I can write");
        Console.WriteLine("I can walk");
    }
}

class App
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Human Skills:");
        
        Human human = new Human(new Living());
        human.Describe();

        Console.WriteLine();

        Console.WriteLine("Bird Skills:");
        Bird bird = new Bird(new Living());
        bird.Describe();
    }
}
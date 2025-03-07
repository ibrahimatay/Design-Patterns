namespace DesignPatterns.State;

public interface IEmotion
{
    void SayHello();
    void SayGoodbye();
}

public class Happy : IEmotion
{
    public void SayHello() => Console.WriteLine("Hello, friend!");
    public void SayGoodbye() => Console.WriteLine("Goodbye, friend!");
}

public class Sad : IEmotion
{
    public void SayHello() => Console.WriteLine("Hello");
    public void SayGoodbye() => Console.WriteLine("Bye.");
}

public class Human(IEmotion emotion) : IEmotion
{
    public void SayHello()=> emotion.SayHello();
    public void SayGoodbye()=> emotion.SayGoodbye();
}

class App
{
    public static void Main()
    {
        var me = new Human(new Happy());
        me.SayHello();
        me.SayGoodbye();

        var smith = new Human(new Sad());
        smith.SayHello();
        smith.SayGoodbye();
    }
}
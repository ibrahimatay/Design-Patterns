Human me = new Human(new Happy());
me.SayHello();
me.SayGoodbye();

Human smith = new Human(new Sad());
smith.SayHello();
smith.SayGoodbye();


interface IEmotion
{
    void SayHello();
    void SayGoodbye();
}

class Happy : IEmotion
{
    public void SayHello() => Console.WriteLine("Hello, friend!");

    public void SayGoodbye() => Console.WriteLine("Bye, friend!");
}

class Sad : IEmotion
{
    public void SayHello() => Console.WriteLine("Hello");

    public void SayGoodbye() => Console.WriteLine("Bye.");
}

record Human(IEmotion Emotion) : IEmotion
{
    public void SayHello() => Emotion.SayHello();
    public void SayGoodbye() => Emotion.SayGoodbye();
}
namespace DesignPatterns.SingletonFullyLazy;

class FullyLazySingleton
{
    private FullyLazySingleton() { }
    
    private int _counter = 0;
    
    public static FullyLazySingleton Instance => Nested.Instance;
    
    public void Increment()
    {
        _counter++;
        Console.WriteLine($"Current count: {_counter}");
    }
    
    private class Nested
    {
        static Nested() { }
        internal static readonly FullyLazySingleton Instance = new FullyLazySingleton();
    }
}

class App
{
    public static void Main()
    {
        var instance1 = FullyLazySingleton.Instance;
        var instance2 = FullyLazySingleton.Instance;

        instance1.Increment(); // Output: Current count: 1
        instance2.Increment(); // Output: Current count: 2
        
        Console.WriteLine(ReferenceEquals(instance1, instance2)); // Output: True
    }
}
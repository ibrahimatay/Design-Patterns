namespace DesignPatterns.SingletonNotThreadSafe;

class BasicSingleton
{
    private static BasicSingleton? _instance;
    private BasicSingleton() { }
        
    public static BasicSingleton Instance => _instance ??= new BasicSingleton();
}

class Program
{
    static void Main()
    {
        // Get the instance of the Singleton class
        BasicSingleton instance1 = BasicSingleton.Instance;
        BasicSingleton instance2 = BasicSingleton.Instance;
        
        // Check if both instances are the same
        Console.WriteLine(ReferenceEquals(instance1, instance2) 
            ? "Both instances are the same." 
            : "Instances are different!");
    }
}
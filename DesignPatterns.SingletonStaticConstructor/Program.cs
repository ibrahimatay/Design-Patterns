namespace DesignPatterns.SingletonStaticConstructor;

using System;

class StaticConstructorSingleton
{
    private static readonly StaticConstructorSingleton _instance = new StaticConstructorSingleton();

    static StaticConstructorSingleton() { }
    private StaticConstructorSingleton() { }

    public static StaticConstructorSingleton Instance => _instance;

    // Example property to hold configuration settings
    public string ConfigValue { get; set; } = "Default Value";
}

class App
{
    public static void Main()
    {
        // Setting a configuration value using the singleton instance
        StaticConstructorSingleton.Instance.ConfigValue = "Production Mode";

        // Retrieving the value from a different reference
        Console.WriteLine("Configuration Value: " + StaticConstructorSingleton.Instance.ConfigValue);
        
        // Getting another reference to the singleton instance
        var anotherReference = StaticConstructorSingleton.Instance;
        Console.WriteLine("Value from another reference: " + anotherReference.ConfigValue);

        // Checking if both references point to the same instance
        Console.WriteLine("Are both references the same instance? " + (anotherReference == StaticConstructorSingleton.Instance));
    }
}

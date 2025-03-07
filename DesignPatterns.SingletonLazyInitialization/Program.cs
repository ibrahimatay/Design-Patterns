using System.Collections.Concurrent;

namespace DesignPatterns.SingletonLazyInitialization;

class LazySingleton
{
    private static readonly Lazy<LazySingleton> _instance = new(() => new LazySingleton());

    // Using ConcurrentDictionary to ensure thread-safe settings storage
    private readonly ConcurrentDictionary<string, string> _settings;

    private LazySingleton() 
    {
        // Load default settings
        _settings = new ConcurrentDictionary<string, string>
        {
            ["AppName"] = "LazySingletonApp",
            ["Version"] = "1.0.0",
            ["Theme"] = "Dark"
        };
    }

    public static LazySingleton Instance => _instance.Value;

    // Retrieve a setting value
    public string GetSetting(string key)
    {
        return _settings.TryGetValue(key, out string value) ? value : "Not Found";
    }

    // Update a setting value
    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }
}

class App
{
    static void Main()
    {
        Console.WriteLine("Starting multi-threaded test...");

        // Run multiple threads in parallel to access and modify Singleton instance
        Parallel.For(0, 5, i =>
        {
            LazySingleton config = LazySingleton.Instance;
            string threadName = $"Thread-{i + 1}";

            // Each thread modifies a shared setting
            config.SetSetting("LastAccessedBy", threadName);
            Console.WriteLine($"{threadName} -> Last accessed by: {config.GetSetting("LastAccessedBy")}");
        });

        // Main thread checks the final value of the shared setting
        LazySingleton mainConfig = LazySingleton.Instance;
        Console.WriteLine($"Main thread -> Last accessed by: {mainConfig.GetSetting("LastAccessedBy")}");

        // Verify that all instances reference the same Singleton object
        Console.WriteLine($"Is mainConfig the same as LazySingleton.Instance? {ReferenceEquals(mainConfig, LazySingleton.Instance)}");

        Console.WriteLine("Multi-threaded test completed.");
    }
}
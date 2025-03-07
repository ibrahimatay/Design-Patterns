namespace DesignPatterns.SingletonDoubleCheckLocking;

class ThreadSafeSingleton
{
    private static ThreadSafeSingleton _instance;
    private static readonly object _lock = new object();
        
    private ThreadSafeSingleton() { }
        
    public static ThreadSafeSingleton Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ThreadSafeSingleton();
                }
            }
            
            return _instance;
        }
    }
}

class App
{
    public static void Main()
    {
        Console.WriteLine("Thread-safe Singleton example is starting...\n");

        // Creating two separate threads to test the singleton instance
        Thread thread1 = new Thread(() =>
        {
            ThreadSafeSingleton instance1 = ThreadSafeSingleton.Instance;
            Console.WriteLine($"Thread 1 - Instance ID: {instance1.GetHashCode()}");
        });

        Thread thread2 = new Thread(() =>
        {
            ThreadSafeSingleton instance2 = ThreadSafeSingleton.Instance;
            Console.WriteLine($"Thread 2 - Instance ID: {instance2.GetHashCode()}");
        });

        // Start both threads
        thread1.Start();
        thread2.Start();

        // Wait for both threads to complete
        thread1.Join();
        thread2.Join();

        Console.WriteLine("\nChecking if the same instance was used...");
    }
}
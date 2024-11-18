using System.Threading;

// Lock Class
// https://learn.microsoft.com/en-us/dotnet/api/system.threading.lock?view=net-9.0

// Locking with .NET 9.0's System.Threading.Lock, even on older frameworks
// https://www.reddit.com/r/csharp/comments/1f6ari2/locking_with_net_90s_systemthreadinglock_even_on/

Singleton instance = Singleton.Instance;

Console.WriteLine(instance.CurrentDateTime);

Task.Factory.StartNew(()=>{
    Singleton instance2 = Singleton.Instance;
    Console.WriteLine(instance2.CurrentDateTime);
});


public class Singleton 
{
    #if NET9_0_OR_GREATER
        var _lock = new Lock;
    #else
        var _lock = new object();
    #endif

    private static Singleton instance = null;

    public DateTime CurrentDateTime => _currentDateTime;
    private DateTime _currentDateTime;

    private  Singleton() { }

    public static Singleton Instance {
        get {
            if (instance == null) {
                lock(_lock) {
                    if (instance == null) {
                        instance = new();
                        instance._currentDateTime = DateTime.Now;
                    }
                }
            }
            return instance;
        }
    }

    
}
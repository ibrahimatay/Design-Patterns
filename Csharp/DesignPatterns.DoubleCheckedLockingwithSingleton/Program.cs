
Singleton instance = Singleton.Instance;

Console.WriteLine(instance.CurrentDateTime);

Task.Factory.StartNew(()=>{
    Singleton instance2 = Singleton.Instance;
    Console.WriteLine(instance2.CurrentDateTime);
});


public class Singleton 
{
    private static readonly object _lock = new object();
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
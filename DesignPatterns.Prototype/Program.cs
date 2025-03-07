namespace DesignPatterns.Prototype;

public interface IEngine
{
    IEngine Copy();
}

public class Machine
{
    private readonly List<IEngine> _engines = new();

    public void Add(IEngine engine) => _engines.Add(engine);
    
    public List<IEngine> GetEngines() => _engines;
}

public class ViewEngine : IEngine
{
    public ViewEngine(string name) => Console.WriteLine($"Engine name is: {name}");

    public IEngine Copy() => this;
}

public class DataManagementEngine : IEngine
{
    public DataManagementEngine(string name) => Console.WriteLine($"Engine name is: {name}");

    public IEngine Copy() => this;
}

class App
{
    public static void Main()
    {
        var machine = new Machine();

        IEngine dataManagementEngine = new DataManagementEngine("Data Management Engine");
        machine.Add(dataManagementEngine);
        Console.WriteLine("Added data management instance");
        machine.Add(dataManagementEngine.Copy());
        Console.WriteLine("Added second data management instance (copy)");

        IEngine viewEngine = new ViewEngine("View Engine");
        machine.Add(viewEngine);
        Console.WriteLine("Added view engine instance");
        machine.Add(viewEngine.Copy());
        Console.WriteLine("Added second view engine instance (copy)");

        machine.GetEngines().ForEach(Console.WriteLine);
    }
}
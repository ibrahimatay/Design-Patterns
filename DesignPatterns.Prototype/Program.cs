Machine machine = new Machine();

IEngine dataManagementEngine = new DataManagementEngine("Data Management Engine");
machine.Add(dataManagementEngine);
Console.WriteLine("added data management instance");

machine.Add(dataManagementEngine.Copy());
Console.WriteLine("added second data management instance (copy)");

IEngine viewEngine = new ViewEngine("View Engine");
machine.Add(viewEngine);
Console.WriteLine("added view engine instance");

machine.Add(viewEngine.Copy());
Console.WriteLine("added second view engine instance (copy)");

foreach (var engine in machine.GetEngines())
{
    Console.WriteLine(engine);
}


interface IEngine
{
    IEngine Copy();
}

class Machine
{
    private readonly List<IEngine> _engines = new();

    public void Add(IEngine engine) => _engines.Add(engine);

    public List<IEngine> GetEngines() => _engines;
}

class ViewEngine : IEngine
{
    public ViewEngine(String name) => Console.WriteLine($"Engine name is: {name}");

    public IEngine Copy() => this;
}

class DataManagementEngine : IEngine
{
    public DataManagementEngine(String name) => Console.WriteLine($"Engine name is: {name}");

    public IEngine Copy() => this;
}
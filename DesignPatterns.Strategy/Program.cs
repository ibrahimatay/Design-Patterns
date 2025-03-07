namespace DesignPatterns.Strategy;

public interface IPlugin
{
    void Call();
}

public class PluginManager(params IPlugin[] plugins)
{
    private readonly List<IPlugin> _plugins = [..plugins];
    public void Call() => _plugins.ForEach(p => p.Call());
}

public class EnginePlugin : IPlugin
{
    public void Call() => Console.WriteLine("Engine Plugin Called");
}

public class DataManagementPlugin : IPlugin
{
    public void Call() => Console.WriteLine("Data Management Plugin Called");
}

class App
{
    public static void Main()
    {
        var pluginManager = new PluginManager(new DataManagementPlugin(), new EnginePlugin());
        pluginManager.Call();
    }
}
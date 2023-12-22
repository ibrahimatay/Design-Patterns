PluginManager pluginManager = new PluginManager(new DataManagementPlugin(), new EnginePlugin());
pluginManager.Call();

interface IPlugin
{
    void Call();
}

class PluginManager
{
    private readonly List<IPlugin> _plugins = new();

    public PluginManager(params IPlugin[] plugins) => _plugins.AddRange(plugins);

    public void Call() => _plugins.ForEach(Console.WriteLine);
}

class EnginePlugin : IPlugin
{
    public void Call() => Console.WriteLine("Engine Plugin Called");
}

class DataManagementPlugin : IPlugin
{
    public void Call() => Console.WriteLine("Data Management Plugin Called");
}
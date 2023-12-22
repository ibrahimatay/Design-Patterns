

PluginManager pluginManager = new PluginManager(new DataManagementPlugin(), new EnginePlugin());
pluginManager.Call();

interface IPlugin
{
    void Call();
}

class PluginManager
{
    readonly List<IPlugin> _plugins;

    public PluginManager(params IPlugin[] plugins)
    {
        _plugins = new List<IPlugin>();
        _plugins.AddRange(plugins);
    }

    public void Call()
    {
        foreach (IPlugin plugin in _plugins)
        {
            plugin.Call();
        }
    }
}

class EnginePlugin : IPlugin
{
    public void Call()
    {
        Console.WriteLine("Engine Plugin Called");
    }
}

class DataManagementPlugin : IPlugin
{
    public void Call()
    {
        Console.WriteLine("Data Management Plugin Called");
    }
}
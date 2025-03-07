interface ICommand
{
    void Execute(string query);
}

interface IConnection
{
    void Connect();
    void Disconnect();
}

interface IDatabaseFactory
{
    IConnection CreateConnection();
    ICommand CreateCommand(IConnection connection);
}

class Db2Command : ICommand
{
    public void Execute(string query) => Console.WriteLine("Db2 query executed");
}

class Db2Connection : IConnection
{
    public void Connect() => Console.WriteLine("Db2 connection connected");

    public void Disconnect() => Console.WriteLine("Db2 connection disconnected");
}

class Db2DatabaseFactory : IDatabaseFactory
{
    public IConnection CreateConnection() => new Db2Connection();
    public ICommand CreateCommand(IConnection connection) => new Db2Command();
}

class App
{
    public static void Main()
    {
        IDatabaseFactory db2DatabaseFactory = new Db2DatabaseFactory();
        IConnection connection = db2DatabaseFactory.CreateConnection();
        ICommand command = db2DatabaseFactory.CreateCommand(connection);

        connection.Connect();
        command.Execute("SELECT * FROM PRODUCT");
        connection.Disconnect();
    }
}
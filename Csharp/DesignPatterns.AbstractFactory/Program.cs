var db2DatabaseFactory = new Db2DatabaseFactory();
var connection = db2DatabaseFactory.CreateConnection();
var command = db2DatabaseFactory.CreateCommand(connection);

connection.Connect();
command.Execute("select * from product");
connection.Disconnect();

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
    public void Execute(String query) => Console.WriteLine("Db2 query executed");
}

class Db2Connection : IConnection
{
    public void Connect() => Console.WriteLine("Connection is connected.");
    public void Disconnect() => Console.WriteLine("Connection is disconnected.");
}

class Db2DatabaseFactory : IDatabaseFactory
{
    public IConnection CreateConnection()
    {
        return new Db2Connection();
    }

    public ICommand CreateCommand(IConnection connection)
    {
        if (connection == null)
        {
            throw new NullReferenceException();
        }

        return new Db2Command();
    }
}
namespace DesignPatterns.Builder;

class ConnectionBuilder {
    private class Connection {
        public string Database;
        public string Server;
        public string UserId;
        public string Password;

        public override string ToString() 
            => $"Server={Server};Database={Database};UserId={UserId};Password={Password};";
    }

    readonly Connection _connection;
    public ConnectionBuilder() {
        _connection = new Connection();
    }

    public ConnectionBuilder SetDatabase(String database) {
        _connection.Database = database;
        return this;
    }

    public ConnectionBuilder SetServer(String server) {
        _connection.Server = server;
        return this;
    }

    public ConnectionBuilder SetUserId(String userId) {
        _connection.UserId = userId;
        return this;
    }

    public ConnectionBuilder SetPassword(String password) {
        _connection.Password = password;
        return this;
    }

    public String Build() => _connection.ToString();
    public void Build(Action<string> action) => action.Invoke(_connection.ToString());
}

class App
{
    public static void Main(string[] args)
    {
        new ConnectionBuilder()
            .SetServer("127.0.0.1")
            .SetDatabase("Northwind")
            .SetUserId("Nancy")
            .SetPassword("123456")
            .Build(Console.WriteLine);
    }
}
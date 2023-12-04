package com.ibrahimatay;

class ConnectionBuilder {
    private class Connection {
        public String database;
        public String server;
        public String userId;
        public String password;

        @Override
        public String toString() {
            return "Server=%s;Database=%s;UserId=%s;Password=%s;"
                    .formatted(server, database, userId, password);
        }
    }

    private final Connection connection;
    ConnectionBuilder() {
        connection = new Connection();
    }

    public ConnectionBuilder setDatabase(String database) {
        connection.database = database;
        return this;
    }

    public ConnectionBuilder setServer(String server) {
        connection.server = server;
        return this;
    }

    public ConnectionBuilder setUserId(String userId) {
        connection.userId = userId;
        return this;
    }

    public ConnectionBuilder setPassword(String password) {
        connection.password = password;
        return this;
    }

    public String Build() {
        return connection.toString();
    }
}

public class Main {
    public static void main(String[] args) {
        String connectionString = new ConnectionBuilder()
                .setServer("127.0.0.1")
                .setDatabase("Northwind")
                .setUserId("Nancy")
                .setPassword("123456")
                .Build();

        System.out.println(connectionString);
    }
}
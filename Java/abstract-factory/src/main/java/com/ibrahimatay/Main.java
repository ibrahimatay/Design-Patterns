package com.ibrahimatay;

interface Command {
    void execute(String query);
}

interface Connection {
    void connect();
    void disconnect();
}

interface DatabaseFactory {
    Connection createConnection();
    Command createCommand(Connection connection);
}

class Db2Command implements Command {
    @Override
    public void execute(String query) {
        System.out.println("Db2 query executed");
    }
}

class Db2Connection implements Connection {

    @Override
    public void connect() {
        System.out.println("Connection is connected.");
    }

    @Override
    public void disconnect() {
        System.out.println("Connection is disconnected.");
    }
}

class Db2DatabaseFactory implements DatabaseFactory {

    @Override
    public Connection createConnection() {
        return new Db2Connection();
    }

    @Override
    public Command createCommand(Connection connection) {
        if(connection == null) {
            throw new NullPointerException();
        }
        return new Db2Command();
    }
}

public class Main {
    public static void main(String[] args) {
        DatabaseFactory db2DatabaseFactory = new Db2DatabaseFactory();
        Connection connection = db2DatabaseFactory.createConnection();
        Command command = db2DatabaseFactory.createCommand(connection);

        connection.connect();
        command.execute("select * from product");
        connection.disconnect();
    }
}
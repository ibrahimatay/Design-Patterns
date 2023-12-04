package com.ibrahimatay;

interface Command {
    void execute();
}

class Controller {
    public void invoke(Command command) {
        command.execute();
    }
}

class AddPostCommand implements Command {
    public void execute() {
        System.out.println("Added to Post");
    }
}

class UpdatePostCommand implements Command {
    public void execute() {
        System.out.println("Updated to Post");
    }
}

public class Main {
    public static void main(String[] args) {
        Command addCommand = new AddPostCommand();
        Command updateCommand = new UpdatePostCommand();

        Controller controller = new Controller();

        controller.invoke(addCommand);
        controller.invoke(updateCommand);
    }
}
namespace DesignPatterns.Command;

interface ICommand 
{
    void Execute();
}

class Controller {
    public void Invoke(ICommand command) => command.Execute();
}

class AddPostCommand : ICommand 
{
    public void Execute() => Console.WriteLine($"{nameof(AddPostCommand)} executed");
}

class UpdatePostCommand : ICommand 
{
    public void Execute() => Console.WriteLine($"{nameof(UpdatePostCommand)} executed");
}

class App
{
    public static void Main()
    {
        ICommand addCommand = new AddPostCommand();
        ICommand updateCommand = new UpdatePostCommand();

        Controller controller = new Controller();

        controller.Invoke(addCommand);
        controller.Invoke(updateCommand);
    }
}
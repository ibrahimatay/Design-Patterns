var addCommand = new AddPostCommand();
var updateCommand = new UpdatePostCommand();

Controller controller = new Controller();

controller.Invoke(addCommand);
controller.Invoke(updateCommand);


interface ICommand
{
    void Execute();
}

class Controller
{
    public void Invoke(ICommand command)
    {
        command.Execute();
    }
}

class AddPostCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Added to Post");
    }
}

class UpdatePostCommand : ICommand
{
    public void Execute()
    {
        Console.WriteLine("Updated to Post");
    }
}
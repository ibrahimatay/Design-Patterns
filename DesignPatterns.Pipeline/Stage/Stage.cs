namespace DesignPatterns.Pipeline.Stage;

public interface IStage<Message>
{
    Message Execute(Message input);
}
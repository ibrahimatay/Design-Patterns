using DesignPatterns.Pipeline.Stage;

namespace DesignPatterns.Pipeline.Pipelines;

public interface IPipeline<Messages>
{
    void Add(IStage<Messages> stage);
    void Execute();
}
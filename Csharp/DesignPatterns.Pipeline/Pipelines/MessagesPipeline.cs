using DesignPatterns.Pipeline.Model;
using DesignPatterns.Pipeline.Stage;

namespace DesignPatterns.Pipeline.Pipelines;

public class MessagesPipeline : IPipeline<Messages>
{
    private List<IStage<Messages>> stages = new();
    
    public void Add(IStage<Messages> stage)
    {
        stages.Add(stage);
    }

    public void Execute()
    {
        Messages input = null;
        Messages output = null;

        foreach (IStage<Messages> stage in stages)
        {
            output = stage.Execute(input);
            input = output;
        }
    }
}
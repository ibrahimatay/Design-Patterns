using DesignPatterns.Pipeline.Pipelines;
using DesignPatterns.Pipeline.Stage;

var pipeline = new MessagesPipeline();
pipeline.Add(new CreateMessagesStage());
pipeline.Add(new RemoveDuplicatesStage());
pipeline.Add(new SortMessagesStage());
pipeline.Add(new OutputMessagesStage());

pipeline.Execute();

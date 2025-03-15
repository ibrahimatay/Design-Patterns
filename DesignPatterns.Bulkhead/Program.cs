// Bulkhead pattern
// https://learn.microsoft.com/en-us/azure/architecture/patterns/bulkhead

using System.Collections.Concurrent;

namespace DesignPatterns.Bulkhead;

class Program
{
    static readonly int MaxParallelTasks = 3; // Maximum number of concurrent tasks
    static readonly int MaxQueueSize = 5; // Maximum number of tasks in the queue
    static readonly SemaphoreSlim _semaphore = new(MaxParallelTasks);
    static readonly ConcurrentQueue<Func<Task>> _taskQueue = new();
    
    static async Task Main(string[] args)
    {
        var tasks = new Task[100];

        for (int i = 0; i < 100; i++)
        {
            int taskId = i;
            tasks[i] = EnqueueTask(async () =>
            {
                Console.WriteLine($"Task {taskId} started. Thread ID: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(2000); // Simulating processing time
                Console.WriteLine($"Task {taskId} completed.");
            });
        }

        await Task.WhenAll(tasks);
        Console.WriteLine("All tasks completed.");
    }

    private static async Task EnqueueTask(Func<Task> task)
    {
        if (_taskQueue.Count >= MaxQueueSize)
        {
            Console.WriteLine("Task rejected! Bulkhead capacity is full.");
            return;
        }

        _taskQueue.Enqueue(task);
        await ProcessQueue();
    }

    private static async Task ProcessQueue()
    {
        while (_taskQueue.TryDequeue(out var task))
        {
            await _semaphore.WaitAsync();
            _ = Task.Run(async () =>
            {
                try
                {
                    await task();
                }
                finally
                {
                    _semaphore.Release();
                }
            });
        }
    }
}
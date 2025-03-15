// Circuit Breaker pattern
// https://learn.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker

// Implement the Circuit Breaker pattern
// https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-circuit-breaker-pattern 

namespace DesignPatterns.CircuitBreaker;

class CircuitBreaker(int failureThreshold, TimeSpan openDuration)
{
    int _failureCount = 0;
    DateTime _lastFailureTime;
    bool _isOpen;

    public bool CanExecute()
    {
        // If the circuit is open and the open duration has passed, reset the circuit
        if (_isOpen && DateTime.UtcNow - _lastFailureTime > openDuration)
        {
            Console.WriteLine("Circuit is half-open. Retrying...");
            _isOpen = false;
            _failureCount = 0; // Close the circuit and reset failure count
            return true;
        }
        return !_isOpen;
    }

    public void RecordSuccess() =>  _failureCount = 0; // Reset failure count on success
    
    public void RecordFailure()
    {
        _failureCount++;
        // If failure count reaches the threshold, open the circuit
        if (_failureCount >= failureThreshold)
        {
            _isOpen = true;
            _lastFailureTime = DateTime.UtcNow;
            Console.WriteLine($"Circuit is open! Requests will be blocked for {openDuration.TotalSeconds} seconds.");
        }
    }
}

class Program
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private static readonly CircuitBreaker _circuitBreaker = new CircuitBreaker(2, TimeSpan.FromSeconds(5));

    static async Task Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"Performing request {i}...");
            await MakeRequest();
            Thread.Sleep(1000);
        }
    }

    private static async Task MakeRequest()
    {
        if (!_circuitBreaker.CanExecute())
        {
            Console.WriteLine("Circuit is open! Request canceled.");
            return;
        }

        try
        {
            Console.WriteLine("Sending HTTP request...");
            if (new Random().Next(1, 4) != 1) // Simulated failure rate (fails 2 out of 3 times)
            {
                throw new HttpRequestException("Connection error!");
            }
            Console.WriteLine("Request successful!");
            _circuitBreaker.RecordSuccess();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred: {ex.Message}");
            _circuitBreaker.RecordFailure();
        }
    }
}

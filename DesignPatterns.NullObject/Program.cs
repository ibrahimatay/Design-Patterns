namespace DesignPatterns.NullObject;

// The Null Object Pattern, Bobby Woolf
// http://www.cs.uni.edu/~wallingf/patterns/elementary/papers/null-object.pdf

public interface ICustomer
{
    string Name { get; }
    decimal DiscountRate { get; }
    bool IsNull { get; }

    void PrintInfo();

    static abstract ICustomer Empty { get; }
}
public sealed class Customer(string name, decimal discountRate) : ICustomer
{
    public string Name { get; } = name;
    public decimal DiscountRate { get; } = discountRate;
    public bool IsNull => false;
    
    public string DisplayName
    {
        get => field ??= $"{Name} (Standard Customer)";
    }

    public void PrintInfo()
        => Console.WriteLine($"Customer: {DisplayName}, Discount Rate: %{DiscountRate:0}");

    public static ICustomer Empty => NullCustomer.Instance;
}
public sealed class NullCustomer : ICustomer
{
    public static readonly NullCustomer Instance = new();

    private NullCustomer() { }

    public string Name => "Unknown Customer";
    public decimal DiscountRate => 0m;
    public bool IsNull => true;

    public void PrintInfo()
        => Console.WriteLine("Customer information not found (Null Object).");

    public static ICustomer Empty => Instance;
}

public static class CustomerRepository
{
    private static readonly List<Customer> _customers =
    [
        new("Customer01", 10m),
        new("Customer02", 15m),
    ];

    public static ICustomer FindByName(string name)
    {
        foreach (var customer in _customers)
        {
            if (customer.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return customer;
            }
        }
        
        return Customer.Empty;
    }
}
public static class CustomerExtensions
{
    extension(ICustomer customer)
    {
        public string SummaryText =>
            customer.IsNull
                ? "No registered customer."
                : $"A %{customer.DiscountRate:0} discount can be applied for {customer.Name}.";
    }
}
public static class Program
{
    public static void Main()
    {
        ICustomer[] results =
        [
            CustomerRepository.FindByName("Customer01"),
            CustomerRepository.FindByName("Nonexistent Person"),
        ];

        foreach (var customer in results)
        {
            customer.PrintInfo();
            Console.WriteLine(customer.SummaryText);
            Console.WriteLine(new string('-', 40));
        }
    }
}
namespace DesignPatterns.Flyweight;

enum CalculateType
{
    Adder, Multiplier
}

interface ICalculator
{
    void Calculate(int val1, int val2);
}

class CalculateMultiplier : ICalculator
{
    public void Calculate(int val1, int val2) =>Console.WriteLine($"{val1} * {val2} = {val1 * val2}");
}

class CalculateAdder : ICalculator
{
    public void Calculate(int val1, int val2)=> Console.WriteLine($"{val1} + {val2} = {val1 + val2}");
}

class CalculatorFactory
{
    private readonly Dictionary<CalculateType, ICalculator> _memoryObject = new();

    public ICalculator GetCalculator(CalculateType type)
    {
        if (!_memoryObject.ContainsKey(type))
        {
            _memoryObject[type] = type switch
            {
                CalculateType.Adder => new CalculateAdder(),
                CalculateType.Multiplier => new CalculateMultiplier(),
                _ => throw new ArgumentException("Invalid type")
            };
        }
            
        return _memoryObject[type];
    }
}

class App
{
    public static void Main(string[] args)
    {
        var calculatorFactory = new CalculatorFactory();

        ICalculator adder = calculatorFactory.GetCalculator(CalculateType.Adder);
        adder.Calculate(1, 2);

        ICalculator multiplier = calculatorFactory.GetCalculator(CalculateType.Multiplier);
        multiplier.Calculate(4, 2);
    }
}
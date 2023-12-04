
var calculatorFactory = new CalculatorFactory();

var adder = calculatorFactory.GetCalculator(CalculateType.Adder);
adder.Calculate(1, 2);

var multiplier = calculatorFactory.GetCalculator(CalculateType.Multiplier);
multiplier.Calculate(4, 2);


public enum CalculateType
{
    Default = 0,
    Adder = 1,
    Multiplier = 2
}

interface ICalculator
{
    void Calculate(int val1, int val2);
}

class CalculateMultiplier : ICalculator
{
    public void Calculate(int val1, int val2)
    {
        Console.WriteLine($"{val1} * {val2} = {val1 * val2}");
    }
}

class CalculateAdder : ICalculator
{
    public void Calculate(int val1, int val2)
    {
        Console.WriteLine($"{val1} + {val2} = {val1 + val2}");
    }
}

class CalculatorFactory
{
    public ICalculator GetCalculator(CalculateType type)
    {
        if (type == CalculateType.Adder)
        {
            return new CalculateAdder();
        }

        if (type == CalculateType.Multiplier)
        {
            return new CalculateMultiplier();
        }

        throw new Exception();
    }
}
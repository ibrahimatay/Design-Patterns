namespace DesignPatterns.Visitor;

public interface IVisitor
{
    void Visit(Computer computer);
}

public abstract class Computer
{
    string Name { get; }
    string Brand { get; }

    protected Computer(string name, string brand)
    {
        Name = name;
        Brand = brand;
    }

    public abstract void Accept(IVisitor visitor);

    public override string ToString() => $"Computer:{{ Name='{Name}', Brand='{Brand}' }}";
}

public class MacComputer : Computer
{
    public MacComputer() : base("Mac", "Apple") { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class PcComputer : Computer
{
    public PcComputer() : base("PC", "Any brand") { }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

public class ExternalPowerVisitor : IVisitor
{
    public void Visit(Computer computer) 
        =>  Console.WriteLine(computer switch
        {
            MacComputer => "MAC has external power",
            _ => "Unsupported external power"
        });
}

public class WifiVisitor : IVisitor
{
    public void Visit(Computer computer) 
        => Console.WriteLine(computer switch
        {
            MacComputer => "Mac has Wi-Fi",
            PcComputer => "PC has Wi-Fi",
            _ => "Unsupported Wi-Fi"
        });
}

class App
{
    public static void Main()
    {
        Computer mac = new MacComputer();
        Computer pc = new PcComputer();

        Console.WriteLine(mac);
        mac.Accept(new WifiVisitor());
        mac.Accept(new ExternalPowerVisitor());

        Console.WriteLine(pc);
        pc.Accept(new WifiVisitor());
        pc.Accept(new ExternalPowerVisitor());
    }
}
Computer mac = new MacComputer();
Computer pc = new PcComputer();

Console.WriteLine(mac);
mac.Accept(new WifiVisitor());
mac.Accept(new ExternalPowerVisitor());

Console.WriteLine(pc);
pc.Accept(new WifiVisitor());
pc.Accept(new ExternalPowerVisitor());


interface IVisitor
{
    void Visit(Computer computer);
}

abstract class Computer
{
    readonly String _name;
    readonly String _brand;

    public Computer(String name, String brand)
    {
        this._name = name;
        this._brand = brand;
    }

    public abstract void Accept(IVisitor visitor);
}

class MacComputer : Computer
{
    public MacComputer() : base("Mac", "Apple")
    {
    }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

class PcComputer : Computer
{
    public PcComputer() : base("PC", "Any brand")
    {
    }

    public override void Accept(IVisitor visitor) => visitor.Visit(this);
}

class ExternalPowerVisitor : IVisitor
{
    public void Visit(Computer computer)
        => Console.WriteLine(computer is MacComputer ? "MAC have external power" : "Unsupported external power");
}

class WifiVisitor : IVisitor
{
    public void Visit(Computer computer)
    {
        switch (computer)
        {
            case MacComputer:
                Console.WriteLine("Mac have wi-fi");
                break;
            case PcComputer:
                Console.WriteLine("PC have wi-fi");
                break;
            default:
                Console.WriteLine("Unsupported wifi");
                break;
        }
    }
}
namespace DesignPatterns.Bridge;

interface ILaunch 
{
    void Run();
}

class Engine : ILaunch 
{
    public void Run() => Console.WriteLine("Engine running...");
}

interface IVehicle 
{
    void Drive();
}

class SchoolBus(ILaunch launch) : IVehicle
{
    public void Drive() 
    {
        ArgumentNullException.ThrowIfNull(launch,"There is no engine in the school bus.");

        launch.Run();
        Console.WriteLine("SchoolBus driving");
    }
}

class Taxi(ILaunch launch) : IVehicle
{
    public void Drive() {
        ArgumentNullException.ThrowIfNull(launch,"There is no engine in the car.");
        
        launch.Run();
        Console.WriteLine("Taxi driving");
    }
}

class App
{
    public static void Main(string[] args)
    {
        IVehicle schoolBus = new SchoolBus(new Engine());
        schoolBus.Drive();

        IVehicle taxi = new Taxi(null);
        taxi.Drive();
    }
}
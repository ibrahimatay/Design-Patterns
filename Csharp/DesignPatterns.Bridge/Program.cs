
var schoolBus = new SchoolBus(new Engine());
schoolBus.Drive();

var taxi = new Taxi(null);
taxi.Drive();


interface ILaunch
{
    void Run();
}

class Engine : ILaunch
{
    public void Run()
    {
        Console.WriteLine("Running");
    }
}

interface IVehicle
{
    void Drive();
}

class SchoolBus : IVehicle
{
    readonly ILaunch _launch;

    public SchoolBus(ILaunch launch)
    {
        this._launch = launch;
    }
    
    public void Drive()
    {
        if (_launch == null)
        {
            throw new NullReferenceException("There is no engine in the car.");
        }

        _launch.Run();
        Console.WriteLine("SchoolBus driving");;
    }
}

class Taxi : IVehicle
{
    readonly ILaunch _launch;

    public Taxi(ILaunch launch)
    {
        this._launch = launch;
    }
    
    public void Drive()
    {
        if (_launch == null)
        {
            throw new NullReferenceException("There is no engine in the car.");
        }

        _launch.Run();
        Console.WriteLine("Taxi driving");
    }
}
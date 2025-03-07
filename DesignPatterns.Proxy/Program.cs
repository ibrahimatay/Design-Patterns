namespace DesignPatterns.Proxy;

public record Weather(Guid Id, DateTime DateTime, string CityCode, string CountyCode);

public abstract class WSWeatherForecastClient
{
    public abstract List<Weather> WeathersByCountyCode(string countyCode);
}

public class WSWeatherForecast(string username, string password) : WSWeatherForecastClient
{
    public override List<Weather> WeathersByCountyCode(string countyCode)
    {
        Console.WriteLine($"Connected with username: {username} password: {password}");
        Console.WriteLine("Return of County of Weather");
        return [new Weather(Guid.NewGuid(), DateTime.Now, "IST", "TURKEY")];
    }
}

public class WSWeatherForecastClientProxy : WSWeatherForecastClient
{
    private readonly WSWeatherForecast _weatherForecast = new("username", "password");

    public override List<Weather> WeathersByCountyCode(string countyCode)
    {
        Console.WriteLine("Connecting...");
        return _weatherForecast.WeathersByCountyCode(countyCode);
    }
}

class App
{
    public static void Main()
    {
        WSWeatherForecastClient clientProxy = new WSWeatherForecastClientProxy();
        clientProxy.WeathersByCountyCode("90").ForEach(Console.WriteLine);
    }
}
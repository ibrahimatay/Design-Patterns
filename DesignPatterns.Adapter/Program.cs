namespace DesignPatterns.Adapter;

record Weather(Guid Id, DateTime Date, float MaxTemp, float MinTemp, string CityName);

interface IWeatherAdapter 
{
    List<Weather> WeathersByCountyName(string countyName);
}

class WeatherForecast 
{
    public List<Weather> WeathersByCountyName(String countyName) 
    {
        ArgumentException.ThrowIfNullOrEmpty(countyName);   

        return
        [
            new Weather(Guid.NewGuid(), DateTime.Now, 36.8f, 28.5f, "ISTANBUL"),
            new Weather(Guid.NewGuid(), DateTime.Now, 27.8f, 21.5f, "ANKARA")
        ];
    }
}

class WeatherForecastAdapter : IWeatherAdapter
{
    public List<Weather> WeathersByCountyName(string countyName) =>
        new WeatherForecast().WeathersByCountyName(countyName);
}

class App
{
    public static void Main(string[] args)
    {
        IWeatherAdapter adapter = new WeatherForecastAdapter();
        adapter.WeathersByCountyName("TURKEY").ForEach(Console.WriteLine);
    }
}
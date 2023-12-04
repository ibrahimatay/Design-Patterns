
IWeatherAdapter weatherAdapter = new WeatherForecastAdapter();
weatherAdapter.WeathersByCountyName("TURKEY").ForEach(Console.WriteLine);

record Weather(Guid Id, DateTime Date, float MaxTemp, float MinTemp, String CityName)
{
}

interface IWeatherAdapter
{
    List<Weather> WeathersByCountyName(String countyName);
}

class WeatherForecast
{
    public List<Weather> WeathersByCountyName(String countyName)
    {
        if (string.IsNullOrWhiteSpace(countyName))
        {
            throw new ArgumentException();
        }

        return new List<Weather>()
        {
            new Weather(Guid.NewGuid(), DateTime.Now, 36.8f, 28.5f, "ISTANBUL"),
            new Weather(Guid.NewGuid(), DateTime.Now, 27.8f, 21.5f, "ANKARA")
        };
    }
}

class WeatherForecastAdapter : IWeatherAdapter
{
    public List<Weather> WeathersByCountyName(string countyName)
    {
        WeatherForecast weatherForecast = new WeatherForecast();
        return weatherForecast.WeathersByCountyName(countyName);
    }
}
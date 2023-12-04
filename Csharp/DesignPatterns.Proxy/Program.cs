
IWsWeatherForecastClient clientProxy = new WsWeatherForecastClientProxy();
clientProxy.WeathersByCountyCode("90").ForEach(Console.WriteLine);

record Weather(Guid Id, DateTime DateTime, String CityCode, String CountyCode) {

}

interface IWsWeatherForecastClient {
    List<Weather> WeathersByCountyCode(String countyCode);
}

class WsWeatherForecast : IWsWeatherForecastClient {
    readonly String _username;
    readonly String _password;

    public WsWeatherForecast(String username, String password) {
        this._username = username;
        this._password = password;
    }

    public  List<Weather> WeathersByCountyCode(string countyCode)
    {
        Console.WriteLine($"connected with username:{_username} password:{_password}");
        Console.WriteLine("Return of County of Weather");
        return new List<Weather>()
        {
            new(Guid.NewGuid(), DateTime.Now, "IST", "TURKEY")
        };
    }
}

class WsWeatherForecastClientProxy : IWsWeatherForecastClient {
    readonly WsWeatherForecast _weatherForecast;

    public WsWeatherForecastClientProxy() {
        this._weatherForecast = new ("username", "password");
    }
    
    public List<Weather> WeathersByCountyCode(string countyCode)
    {
        Console.WriteLine("Connecting...");
        return _weatherForecast.WeathersByCountyCode(countyCode);
    }
}
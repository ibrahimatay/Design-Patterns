package com.ibrahimatay;

import java.time.LocalDateTime;
import java.util.List;
import java.util.UUID;
record Weather(UUID id, LocalDateTime dateTime, String cityCode, String countyCode) {

}

abstract class WSWeatherForecastClient {
    abstract List<Weather> weathersByCountyCode(String countyCode);
}

class WSWeatherForecast extends WSWeatherForecastClient {
    final String username;
    final String password;
    WSWeatherForecast(String username, String password) {
        this.username = username;
        this.password = password;
    }

    @Override
    public List<Weather> weathersByCountyCode(String countyCode) {
        System.out.println("connected with username:"+username+" password:"+password);
        System.out.println("Return of County of Weather");
        return List.of(new Weather(UUID.randomUUID(), LocalDateTime.now(), "IST","TURKEY"));
    }
}

class WSWeatherForecastClientProxy extends WSWeatherForecastClient {
    final WSWeatherForecast weatherForecast;

    WSWeatherForecastClientProxy() {
        this.weatherForecast = new WSWeatherForecast("username", "password");
    }

    @Override
    public List<Weather> weathersByCountyCode(String countyCode) {
        System.out.println("Connecting...");
        return weatherForecast.weathersByCountyCode(countyCode);
    }
}

public class Main {
    public static void main(String[] args) {
        WSWeatherForecastClient clientProxy = new WSWeatherForecastClientProxy();
        clientProxy.weathersByCountyCode("90").forEach(System.out::println);
    }
}
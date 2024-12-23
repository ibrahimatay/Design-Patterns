package com.ibrahimatay;

import java.time.LocalDate;
import java.util.*;

record Weather(UUID id, LocalDate date, float maxTemp, float minTemp, String cityName) {

}

interface WeatherAdapter {
    List<Weather> weathersByCountyName(String countyName);
}

class WeatherForecast {
    public List<Weather> weathersByCountyName(String countyName) {
        if (countyName.isEmpty()) {
            throw new IllegalArgumentException();
        }

        return Arrays.asList(
                new Weather(UUID.randomUUID(),LocalDate.now(),36.8f, 28.5f, "ISTANBUL"),
                new Weather(UUID.randomUUID(),LocalDate.now(),27.8f, 21.5f, "ANKARA" ));
    }
}

class WeatherForecastAdapter implements WeatherAdapter {
    @Override
    public List<Weather> weathersByCountyName(String countyName) {
        WeatherForecast weatherForecast = new WeatherForecast();
        return weatherForecast.weathersByCountyName(countyName);
    }
}

public class Main {
    public static void main(String[] args) {
        WeatherAdapter weatherAdapter = new WeatherForecastAdapter();
        weatherAdapter.weathersByCountyName("TURKEY").forEach(System.out::println);
    }
}
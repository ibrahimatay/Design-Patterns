package com.ibrahimatay;

import java.time.LocalDateTime;

class DateTimeSnapshot {
    public String getDateTime() {
        return LocalDateTime.now().toString();
    }
}

final class Singleton {
    private static DateTimeSnapshot instance;

    Singleton() {
        System.out.println("Singleton being initialized");
    }

    public static DateTimeSnapshot getInstance() {
        if(instance == null) {
            System.out.println("make a new instance...");
            instance = new DateTimeSnapshot();
        }

        return instance;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println(Singleton.getInstance().getDateTime());
        System.out.println(Singleton.getInstance().getDateTime());
        System.out.println(Singleton.getInstance().getDateTime());
    }
}
package com.ibrahimatay;

import java.time.LocalDateTime;

class DateTimeSnapshot {
    public String getDateTime() {
        return LocalDateTime.now().toString();
    }
}

final class Singleton {
    private final static DateTimeSnapshot instance = new DateTimeSnapshot();
    public static DateTimeSnapshot getInstance() {
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
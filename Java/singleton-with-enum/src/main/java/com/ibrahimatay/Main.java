package com.ibrahimatay;

import java.time.LocalDateTime;

/*
* https://docs.oracle.com/javase/specs/jls/se8/html/jls-12.html#jls-12.4
* https://docs.oracle.com/javase/specs/jls/se7/html/jls-8.html#jls-8.9
* */

class DateTimeSnapshot {
    public String getDateTime() {
        return LocalDateTime.now().toString();
    }
}

enum Singleton {
    INSTANCE;
    private final DateTimeSnapshot snapshot;

    Singleton() {
        this.snapshot = new DateTimeSnapshot();
    }

    public DateTimeSnapshot getInstance() {
        return snapshot;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println(Singleton.INSTANCE.getInstance().getDateTime());
        System.out.println(Singleton.INSTANCE.getInstance().getDateTime());
    }
}
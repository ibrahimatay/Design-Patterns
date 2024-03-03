package com.ibrahimatay;

import java.util.Random;

class NumberGenerator {
    private final long currentNumber;

    public NumberGenerator() {
        currentNumber = new Random().nextLong(1000);
    }

    public long getNumber() {
        return currentNumber;
    }
}

final class Singleton {
    private static NumberGenerator instance;

    Singleton() {
        System.out.println("Singleton being initialized");
    }

    public static NumberGenerator getInstance() {
        if(instance == null) {
            System.out.println("make a new instance...");
            instance = new NumberGenerator();
        }

        return instance;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println(Singleton.getInstance().getNumber());
        System.out.println(Singleton.getInstance().getNumber());
        System.out.println(Singleton.getInstance().getNumber());
    }
}
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
    private final static NumberGenerator instance = new NumberGenerator();

    public static NumberGenerator getInstance() {
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
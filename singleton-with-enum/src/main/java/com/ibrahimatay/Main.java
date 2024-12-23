package com.ibrahimatay;

import java.util.Random;

/*
* https://docs.oracle.com/javase/specs/jls/se8/html/jls-12.html#jls-12.4
* https://docs.oracle.com/javase/specs/jls/se7/html/jls-8.html#jls-8.9
* */

class NumberGenerator {
    private final long currentNumber;

    public NumberGenerator() {
        currentNumber = new Random().nextLong(1000);
    }

    public long getNumber() {
        return currentNumber;
    }
}

enum Singleton {
    INSTANCE;
    private final NumberGenerator instance;

    Singleton() {
        this.instance = new NumberGenerator();
    }

    public NumberGenerator getInstance() {
        return instance;
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println(Singleton.INSTANCE.getInstance().getNumber());
        System.out.println(Singleton.INSTANCE.getInstance().getNumber());
    }
}
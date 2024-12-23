package com.ibrahimatay;

public class Main {
    public static void main(String[] args) {
        StaticBlockSingleton instance = StaticBlockSingleton.getInstance();
        instance.sayHello();
    }
}

class StaticBlockSingleton {
    private final static StaticBlockSingleton INSTANCE;

    static {
        try {
            INSTANCE = new StaticBlockSingleton();
        } catch (Exception e) {
            throw new RuntimeException("Exception occurred during singleton initialization", e);
        }
    }

    private StaticBlockSingleton() {
    }

    public static StaticBlockSingleton getInstance() {
        return INSTANCE;
    }

    public void sayHello(){
        System.out.println("Hello");
    }
}
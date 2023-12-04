package com.ibrahimatay;

public class StaticBlockSingleton {
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

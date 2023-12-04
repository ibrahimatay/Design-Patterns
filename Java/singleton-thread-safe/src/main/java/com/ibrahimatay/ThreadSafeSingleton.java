package com.ibrahimatay;

public class ThreadSafeSingleton {
    private static ThreadSafeSingleton instance;

    private ThreadSafeSingleton() {

    }

    public static synchronized ThreadSafeSingleton getInstance() {
        if (instance==null){
            instance = new ThreadSafeSingleton();
        }

        return instance;
    }

    public void sayHello() {
        System.out.println("Hello");
    }
}

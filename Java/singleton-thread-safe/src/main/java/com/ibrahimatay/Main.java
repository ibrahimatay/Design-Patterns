package com.ibrahimatay;

public class Main {
    public static void main(String[] args) {
        ThreadSafeSingleton instance = ThreadSafeSingleton.getInstance();
        instance.sayHello();
    }
}

class ThreadSafeSingleton {
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
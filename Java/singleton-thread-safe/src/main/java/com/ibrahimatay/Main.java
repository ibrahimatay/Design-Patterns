package com.ibrahimatay;

public class Main {
    public static void main(String[] args) {
        ThreadSafeSingleton instance = ThreadSafeSingleton.getInstance();
        instance.sayHello();
    }
}
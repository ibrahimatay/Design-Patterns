package com.ibrahimatay;

public class Main {
    public static void main(String[] args) {
        StaticBlockSingleton instance = StaticBlockSingleton.getInstance();
        instance.sayHello();
    }
}
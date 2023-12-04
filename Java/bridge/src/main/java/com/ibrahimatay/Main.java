package com.ibrahimatay;

interface Launch {
    void run();
}

class Engine implements Launch {
    @Override
    public void run() {
        System.out.println("Running");
    }
}

interface Vehicle {
    void drive();
}

class SchoolBus implements Vehicle {
    final Launch launch;
    public SchoolBus(Launch launch) {
        this.launch = launch;
    }

    @Override
    public void drive() {
        if (launch == null) {
            throw new IllegalStateException("There is no engine in the car.");
        }

        launch.run();
        System.out.println("SchoolBus driving");
    }
}

class Taxi implements Vehicle {
    final Launch launch;

    public Taxi(Launch launch) {
        this.launch = launch;
    }

    @Override
    public void drive() {
        if (launch == null) {
            throw new IllegalStateException("There is no engine in the car.");
        }

        launch.run();
        System.out.println("Taxi driving");
    }
}

public class Main {
    public static void main(String[] args) {
        Vehicle schoolBus = new SchoolBus(new Engine());
        schoolBus.drive();

        Vehicle taxi = new Taxi(null);
        taxi.drive();
    }
}
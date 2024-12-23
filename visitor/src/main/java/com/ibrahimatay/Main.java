package com.ibrahimatay;

interface Visitor {
    void visit(Computer computer);
}

abstract class Computer {
    final String name;
    final String brand;

    public Computer(String name, String brand) {
        this.name = name;
        this.brand = brand;
    }

    public abstract void accept(Visitor visitor);

    @Override
    public String toString() {
        return "Computer:{" +
                "_name='" + name + '\'' +
                ", _brand='" + brand + '\'' +
                '}';
    }
}

class MacComputer extends Computer {

    public MacComputer() {
        super("Mac", "Apple");
    }

    @Override
    public void accept(Visitor visitor) {
        visitor.visit(this);
    }
}

class PcComputer extends Computer {
    public PcComputer() {
        super("PC", "Any brand");
    }

    @Override
    public void accept(Visitor visitor) {
        visitor.visit(this);
    }
}

class ExternalPowerVisitor implements Visitor {
    @Override
    public void visit(Computer computer) {
        if (computer instanceof MacComputer) {
            System.out.println("MAC have external power");
        } else {
            System.out.println("Unsupported external power");
        }
    }
}

class WifiVisitor implements Visitor {
    @Override
    public void visit(Computer computer) {
        if (computer instanceof MacComputer) {
            System.out.println("Mac have wi-fi");
        } if (computer instanceof PcComputer) {
            System.out.println("PC have wi-fi");
        } else {
            System.out.println("Unsupported wifi");
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Computer mac = new MacComputer();
        Computer pc = new PcComputer();

        System.out.println(mac);
        mac.accept(new WifiVisitor());
        mac.accept(new ExternalPowerVisitor());

        System.out.println(pc);
        pc.accept(new WifiVisitor());
        pc.accept(new ExternalPowerVisitor());
    }
}
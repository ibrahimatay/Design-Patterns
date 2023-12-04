package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

interface Engine {
    Engine copy();
}

class Machine {
    private final List<Engine> Engines;

    Machine() {
        Engines = new ArrayList<>();
    }

    public void add(Engine engine) {
        this.Engines.add(engine);
    }

    public List<Engine> getEngines() {
        return this.Engines;
    }
}

class ViewEngine implements Engine {

    ViewEngine(String name) {
        System.out.printf("Engine name is: %s\n", name);
    }

    @Override
    public Engine copy() {
        return this;
    }
}

class DataManagementEngine implements Engine {

    DataManagementEngine(String name) {
        System.out.printf("Engine name is: %s\n", name);
    }

    @Override
    public Engine copy() {
        return this;
    }
}

public class Main {
    public static void main(String[] args) {
        Machine machine = new Machine();

        Engine dataManagementEngine = new DataManagementEngine("Data Management Engine");
        machine.add(dataManagementEngine);
        System.out.println("added data management instance");
        machine.add(dataManagementEngine.copy());
        System.out.println("added second data management instance (copy)");

        Engine viewEngine = new ViewEngine("View Engine");
        machine.add(viewEngine);
        System.out.println("added view engine instance");
        machine.add(viewEngine.copy());
        System.out.println("added second view engine instance (copy)");

        for(Engine engine : machine.getEngines()) {
            System.out.println(engine);
        }
    }
}
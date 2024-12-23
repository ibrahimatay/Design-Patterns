package com.ibrahimatay;

import java.util.Dictionary;
import java.util.Hashtable;

enum CalculateType {
    Adder, Multiplier
}

interface Calculator {
    void calculate(int val1, int val2);
}

class CalculateMultiplier implements Calculator {
    @Override
    public void calculate(int val1, int val2) {
        System.out.printf("%d * %d = %d\n", val1, val2, (val1 * val2));
    }
}

class CalculateAdder implements Calculator {
    @Override
    public void calculate(int val1, int val2) {
        System.out.printf("%d + %d = %d\n", val1, val2, (val1 + val2));
    }
}

class CalculatorFactory {
    final Dictionary<CalculateType, Calculator> memoryObject;

    CalculatorFactory() {
        memoryObject = new Hashtable<>();
    }

    public Calculator getCalculator(CalculateType type) {
        Calculator swap = switch (type) {
            case Adder -> new CalculateAdder();
            case Multiplier -> new CalculateMultiplier();
        };

        memoryObject.put(type, swap);

        return swap;
    }
}

public class Main {
    public static void main(String[] args) {

        CalculatorFactory calculatorFactory = new CalculatorFactory();

        Calculator adder = calculatorFactory.getCalculator(CalculateType.Adder);
        adder.calculate(1,2);

        Calculator multiplier = calculatorFactory.getCalculator(CalculateType.Multiplier);
        multiplier.calculate(4, 2);
    }
}
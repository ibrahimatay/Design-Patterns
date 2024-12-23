package com.ibrahimatay;

abstract class BreadMaker {
    protected abstract void bake();
    protected abstract void mixIngredients();
    protected void slice() {
        System.out.println("Slicing the bread!");
    }

    public void make() {
        mixIngredients();
        bake();
        slice();
    }
}

class GrainBread extends BreadMaker {
    @Override
    protected void bake() {
        System.out.println("Baking the Grain Bread. (25 minutes)");
    }

    @Override
    protected void mixIngredients() {
        System.out.println("Gathering Ingredients for Grain Bread.");
    }
}

class WholeWheatBread extends BreadMaker {
    @Override
    protected void bake() {
        System.out.println("Baking the Whole Wheat Bread. (15 minutes)");
    }

    @Override
    protected void mixIngredients() {
        System.out.println("Gathering Ingredients for Whole Wheat Bread.");
    }
}

public class Main {
    public static void main(String[] args) {
        BreadMaker wholeWheat = new WholeWheatBread();
        wholeWheat.make();

        System.out.println();

        BreadMaker grain = new GrainBread();
        grain.make();
    }
}
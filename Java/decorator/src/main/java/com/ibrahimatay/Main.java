package com.ibrahimatay;

interface Animal {
    void describe();
}

final class Living implements Animal {
    @Override
    public void describe() {
        System.out.println("I am animal");
    }
}

abstract class AnimalDecorator implements Animal {
    final Animal animal;

    AnimalDecorator(Animal animal) {
        this.animal = animal;
    }

    public void describe() {
        animal.describe();
    }
}

class Bird extends AnimalDecorator {
    Bird(Animal animal) {
        super(animal);
    }

    @Override
    public void describe() {
        super.describe();
        System.out.println("I can fly");
        System.out.println("I can sing");
    }
}

class Human extends AnimalDecorator {
    Human(Animal animal) {
        super(animal);
    }

    @Override
    public void describe() {
        super.describe();
        System.out.println("I can write");
        System.out.println("I can walk");
    }
}

public class Main {
    public static void main(String[] args) {
        System.out.println("Human Skills:");
        Human human = new Human(new Living());
        human.describe();

        System.out.println();

        System.out.println("Bird Skills:");
        Bird bird = new Bird(new Living());
        bird.describe();
    }
}
package com.ibrahimatay;

interface Emotion {
    void sayHello();
    void sayGoodbye();
}

class Happy implements Emotion {

    @Override
    public void sayHello() {
        System.out.println("Hello, friend!");
    }

    @Override
    public void sayGoodbye() {
        System.out.println("Bye, friend!");
    }
}

class Sad implements Emotion {

    @Override
    public void sayHello() {
        System.out.println("Hello");
    }

    @Override
    public void sayGoodbye() {
        System.out.println("Bye.");
    }
}

record Human(Emotion emotion) implements Emotion {

    @Override
    public void sayHello() {
        emotion.sayHello();
    }

    @Override
    public void sayGoodbye() {
        emotion.sayGoodbye();
    }
}

public class Main {
    public static void main(String[] args) {
        Human me = new Human(new Happy());
        me.sayHello();
        me.sayGoodbye();

        Human smith = new Human(new Sad());
        smith.sayHello();
        smith.sayGoodbye();
    }
}
package com.ibrahimatay;

interface Screen {
    void draw();
}

enum ScreenType {
    Windows, Web
}

class CreatorFactory {
    public static Screen screenCreator(ScreenType screenType) {
        return switch (screenType) {
            case Web -> new WebScreen();
            case Windows -> new WindowsScreen();
            default -> throw new IllegalStateException();
        };
    }
}

class WebScreen implements Screen {
    @Override
    public void draw() {
        System.out.println("Web page is drawing");
    }
}

class WindowsScreen implements Screen {
    @Override
    public void draw() {
        System.out.println("Windows drawing");
    }
}

public class Main {
    public static void main(String[] args) {
        Screen screen = CreatorFactory.screenCreator(ScreenType.Web);
        screen.draw();
    }
}
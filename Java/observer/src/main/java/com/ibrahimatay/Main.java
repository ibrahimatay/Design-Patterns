package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

enum ChangeType {
    Add, Update, Delete
}

record Subscriber(String name)  {
    public void update(Subscriber subscriber, Page page, ChangeType changeType) {
        System.out.println("Subscriber Name:{" + subscriber.name + "} Change Type:{" + changeType.name() + "} Page Name:{" + page.getPageName() + "}");
    }
}

class Page {
    private String name;
    private final List<Subscriber> subscribers;

    public Page() {
        subscribers = new ArrayList<>();
    }

    public String getPageName() {
        return name;
    }

    public void updateToPage(String pageName) {
        this.name = pageName;
        notify(ChangeType.Update);
    }

    public void addToPage(String pageName) {
        this.name = pageName;
        notify(ChangeType.Add);
    }

    public void deleteToPage() {
        notify(ChangeType.Delete);
    }

    public void subscribe(Subscriber subscriber) {
        this.subscribers.add(subscriber);
    }

    private void notify(ChangeType changeType) {
        for (Subscriber subscriber : subscribers) {
            subscriber.update(subscriber, this, changeType);
        }
    }
}

public class Main {
    public static void main(String[] args) {
        Page page = new Page();
        page.subscribe(new Subscriber("Ibrahim"));
        page.subscribe(new Subscriber("Tom"));
        page.subscribe(new Subscriber("Carton"));

        page.addToPage("test1");
        page.updateToPage("test2");
        page.deleteToPage();
    }
}
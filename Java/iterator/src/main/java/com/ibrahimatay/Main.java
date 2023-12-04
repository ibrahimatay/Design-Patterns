package com.ibrahimatay;

import java.util.ArrayList;
import java.util.List;

record Item(String name) {

}

interface Iterator {
    boolean hasNext();
    Item next();
    void add(Item item);
    boolean remove();
}

class ListIterator implements Iterator {
    final List<Item> items;
    Integer index;

    ListIterator() {
        index = 0;
        items = new ArrayList<>();
    }

    @Override
    public boolean hasNext() {
        return index < items.size();
    }

    @Override
    public Item next() {
        Item currentItem = items.get(index);

        index++;
        return currentItem;
    }

    @Override
    public void add(Item item) {
        items.add(item);
    }

    @Override
    public boolean remove() {
        return items.remove(items.get(index));
    }
}

interface Aggregate {
    Iterator createIterator();
}

class ConcreteAggregate implements Aggregate {

    @Override
    public Iterator createIterator() {
        return new ListIterator();
    }
}

public class Main {
    public static void main(String[] args) {
        Item item1 = new Item("Item 1");
        Item item2 = new Item("Item 2");
        Item item3 = new Item("Item 3");
        Item item4 = new Item("Item 4");

        Aggregate concreteAggregate = new ConcreteAggregate();
        Iterator iterator = concreteAggregate.createIterator();

        iterator.add(item1);
        iterator.add(item2);
        iterator.add(item3);
        iterator.add(item4);

        while (iterator.hasNext()) {
            var item = iterator.next();
            System.out.println(item);
        }
    }
}
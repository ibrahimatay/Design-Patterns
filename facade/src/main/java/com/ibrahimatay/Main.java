package com.ibrahimatay;

record Product(String productName, String description, float price) {
}

class Order {
    public boolean addToProduct(Product product) {
        System.out.println("This product is join to sales order:" + product);
        return true;
    }
}

class Stock {
    public boolean checkStockByProduct(Product product) {
        System.out.println("Product is in the stock:" + product);
        return true;
    }

    public boolean lookProductTemporary(Product product) {
        System.out.println("This product is look:" + product);
        return true;
    }
}

class Shopping {
    private final Stock stock;
    private final Order order;

    public Shopping() {
        stock = new Stock();
        order = new Order();
    }

    public boolean salesToProduct(Product product) {
        if (!stock.checkStockByProduct(product)) {
            return false;
        }

        stock.lookProductTemporary(product);
        order.addToProduct(product);

        return true;
    }
}

public class Main {
    public static void main(String[] args) {
        Product product = new Product("Books", "...", 12.99f);

        Shopping shopping = new Shopping();
        if (shopping.salesToProduct(product)) {
            System.out.println("successful!");
        } else {
            System.out.println("Process is failed");
        }
    }
}
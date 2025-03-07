namespace DesignPatterns.Facade;

record Product(string ProductName, string Description, float Price) {
}

class Order {
    public bool AddToProduct(Product product) {
        Console.WriteLine($"This product is join to sales order:{product}");
        return true;
    }
}

class Stock {
    public bool CheckStockByProduct(Product product) {
        Console.WriteLine($"Product is in the stock:{product}");
        return true;
    }

    public bool LookProductTemporary(Product product) {
        Console.WriteLine($"Product is looking temporary:{product}");
        return true;
    }
}

class Shopping {
    private readonly Stock _stock = new();
    private readonly Order _order = new();

    public bool SalesToProduct(Product product) {
        if (!_stock.CheckStockByProduct(product)) {
            return false;
        }

        _stock.LookProductTemporary(product);
        _order.AddToProduct(product);

        return true;
    }
}

class App
{
    public static void Main(string[] args)
    {
        Product product = new ("Books", "...", 12.99f);

        Shopping shopping = new Shopping();
        if (shopping.SalesToProduct(product)) {
            Console.WriteLine("Product is sale to shopping");
        } else {
            Console.WriteLine("Product is not sale to shopping");
        }
    }
}
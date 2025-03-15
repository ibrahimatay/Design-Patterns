// Sagas - Hector Garcia-Molina & Kenneth Salem (1987)
// in docs folder

// Saga distributed transactions pattern
// https://learn.microsoft.com/en-us/azure/architecture/patterns/saga

// Pattern: Saga
// https://microservices.io/patterns/data/saga.html

class OrderService
{
    public async Task CreateOrder(int orderId)
    {
        Console.WriteLine($"[OrderService] Order {orderId} has been created.");
        await Task.Delay(500);
    }

    public async Task CancelOrder(int orderId)
    {
        Console.WriteLine($"[OrderService] Order {orderId} has been canceled.");
        await Task.Delay(500);
    }
}

class PaymentService
{
    public async Task ProcessPayment(int orderId)
    {
        Console.WriteLine($"[PaymentService] Payment for Order {orderId} has been processed.");
        await Task.Delay(500);
        
        // Simulating a failure scenario
        if (orderId % 2 == 0) throw new Exception("Payment processing failed!");
    }

    public async Task RefundPayment(int orderId)
    {
        Console.WriteLine($"[PaymentService] Payment for Order {orderId} has been refunded.");
        await Task.Delay(500);
    }
}

class InventoryService
{
    public async Task UpdateInventory(int orderId)
    {
        Console.WriteLine($"[InventoryService] Inventory updated for Order {orderId}.");
        await Task.Delay(500);
    }

    public async Task RestoreInventory(int orderId)
    {
        Console.WriteLine($"[InventoryService] Inventory restored for Order {orderId}.");
        await Task.Delay(500);
    }
}

class ShippingService
{
    public async Task ShipOrder(int orderId)
    {
        Console.WriteLine($"[ShippingService] Order {orderId} has been shipped.");
        await Task.Delay(500);
    }

    public async Task CancelShipment(int orderId)
    {
        Console.WriteLine($"[ShippingService] Shipment for Order {orderId} has been canceled.");
        await Task.Delay(500);
    }
}

class SagaOrchestrator
{
    readonly OrderService _orderService = new();
    readonly PaymentService _paymentService = new();
    readonly InventoryService _inventoryService = new();
    readonly ShippingService _shippingService = new();

    readonly Stack<Func<Task>> _compensationStack = new();

    public async Task<bool> ProcessOrderAsync(int orderId)
    {
        try
        {
            Console.WriteLine("SAGA: Order processing started...");

            // Step 1: Create Order
            await _orderService.CreateOrder(orderId);
            _compensationStack.Push(() => _orderService.CancelOrder(orderId));

            // Step 2: Process Payment
            await _paymentService.ProcessPayment(orderId);
            _compensationStack.Push(() => _paymentService.RefundPayment(orderId));

            // Step 3: Update Inventory
            await _inventoryService.UpdateInventory(orderId);
            _compensationStack.Push(() => _inventoryService.RestoreInventory(orderId));

            // Step 4: Initiate Shipping
            await _shippingService.ShipOrder(orderId);
            _compensationStack.Push(() => _shippingService.CancelShipment(orderId));

            Console.WriteLine("SAGA: Order successfully completed!");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR: {ex.Message}. Rolling back transactions...");
            await Rollback();
            return false;
        }
    }

    private async Task Rollback()
    {
        while (_compensationStack.Count > 0)
        {
            var rollbackAction = _compensationStack.Pop();
            await rollbackAction();
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        var orchestrator = new SagaOrchestrator();

        int orderId = 2; // Change this to test different scenarios
        bool success = await orchestrator.ProcessOrderAsync(orderId);

        Console.WriteLine(success ? "Order completed successfully!" : "Order failed, all transactions have been rolled back.");
        
        /*
        Failure Scenario (Payment Fails)
        ---
        SAGA: Order processing started...
        [OrderService] Order 2 has been created.
        [PaymentService] Payment for Order 2 has been processed.
        ERROR: Payment processing failed!. Rolling back transactions...
        [OrderService] Order 2 has been canceled.
        Order failed, all transactions have been rolled back.
        
        Successful Order Processing
        ---
        SAGA: Order processing started...
        [OrderService] Order 1 has been created.
        [PaymentService] Payment for Order 1 has been processed.
        [InventoryService] Inventory updated for Order 1.
        [ShippingService] Order 1 has been shipped.
        SAGA: Order successfully completed!
        Order completed successfully!
        */
    }
}

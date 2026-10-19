using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderService
{
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();
    private int nextId = 1;

    public Order CreateOrder(string customerName, string productName, decimal price)
    {
        var order = new Order(nextId++, customerName, productName, price, DateTime.Now);
        allOrders.Add(order);
        pendingQueue.Enqueue(order);
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");
        return order;
    }

    public Order? ProcessNext()
    {
        if (pendingQueue.Count == 0)
            return null;

        var order = pendingQueue.Dequeue();
        undoHistory.Push($"Обработан заказ {order.Id}");
        Console.WriteLine($"Обработан заказ: {order}");
        return order;
    }

    public bool UndoLastAction()
    {
        if (undoHistory.Count == 0)
            return false;

        var action = undoHistory.Pop();
        Console.WriteLine($"Отменено действие: {action}");
        return true;
    }

    public void PrintAllOrders()
    {
        Console.WriteLine($"\nВсе заказы ({allOrders.Count}):");
        foreach (var order in allOrders)
            Console.WriteLine($"  {order}");
    }

    public void PrintPendingQueue()
    {
        Console.WriteLine($"\nОжидают обработки: {pendingQueue.Count}");
        if (pendingQueue.Count > 0)
            Console.WriteLine($"  Первый в очереди: {pendingQueue.Peek()}");
    }

    public void PrintRecentActions()
    {
        Console.WriteLine("\nПоследние действия (от последнего к первому):");
        foreach (var action in undoHistory)
            Console.WriteLine($"  {action}");
    }
}
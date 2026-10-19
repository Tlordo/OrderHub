using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderService
{
    // ЗАДАЧА: объявите три коллекции с точной сигнатурой:
    // List<Order> allOrders — все заказы
    // Queue<Order> pendingQueue — заказы, ожидающие обработки, в порядке поступления
    // Stack<string> undoHistory — история последних действий для отмены
    // подсказка: для каждой коллекции создайте экземпляр прямо в поле
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();

    // счётчик Id: каждый новый заказ получает следующий номер
    private int nextId = 1;

    public Order CreateOrder(string customerName, string productName, decimal price)
    {
        // ЗАДАЧА 1: создайте новый заказ (Id счётчик увеличивается на 1)
        var order = new Order(nextId++, customerName, productName, price, DateTime.Now);

        // ЗАДАЧА 2: добавьте заказ в allOrders
        allOrders.Add(order);

        // ЗАДАЧА 3: добавьте тот же заказ в pendingQueue методом Enqueue
        pendingQueue.Enqueue(order);

        // ЗАДАЧА 4: запишите в undoHistory описание действия для возможной отмены
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");

        // ЗАДАЧА 5: верните созданный заказ
        return order;
    }

    public Order? ProcessNext()
    {
        // ЗАДАЧА 1: если pendingQueue пуст — верните null
        if (pendingQueue.Count == 0)
            return null;

        // ЗАДАЧА 2: извлеките заказ из очереди методом Dequeue (именно он, а не Peek)
        var order = pendingQueue.Dequeue();

        // ЗАДАЧА 3: запишите в undoHistory, какой заказ обработан
        undoHistory.Push($"Обработан заказ {order.Id} для {order.CustomerName}");

        // ЗАДАЧА 4: выведите в консоль $"Обработан заказ: {order}"
        Console.WriteLine($"Обработан заказ: {order}");

        // ЗАДАЧА 5: верните обработанный заказ
        return order;
    }

    public bool UndoLastAction()
    {
        // ЗАДАЧА 1: если undoHistory пуст — верните false
        if (undoHistory.Count == 0)
            return false;

        // ЗАДАЧА 2: извлеките последнее действие методом Pop
        var action = undoHistory.Pop();

        // ЗАДАЧА 3: выведите $"Отменено действие: {action}" и верните true
        Console.WriteLine($"Отменено действие: {action}");
        return true;
    }

    // ЗАДАЧА: допишите три метода-отчёта, используя foreach

    // PrintAllOrders() — все заказы из allOrders по порядку добавления
    public void PrintAllOrders()
    {
        Console.WriteLine($"\nВсе заказы ({allOrders.Count}):");
        foreach (var order in allOrders)
            Console.WriteLine($"  {order}");
    }

    // PrintPendingQueue() — сколько заказов ждёт и какой первый в очереди (Peek, без извлечения)
    public void PrintPendingQueue()
    {
        Console.WriteLine($"\nОжидают обработки: {pendingQueue.Count}");
        if (pendingQueue.Count > 0)
            Console.WriteLine($"  Первый в очереди: {pendingQueue.Peek()}");
    }

    // PrintRecentActions() — содержимое undoHistory (обход идёт от последнего к первому)
    public void PrintRecentActions()
    {
        Console.WriteLine("\nПоследние действия (от последнего к первому):");
        foreach (var action in undoHistory)
            Console.WriteLine($"  {action}");
    }
}

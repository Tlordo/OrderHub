using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class OrderService
{
    // ЗАДАЧА: объявите три коллекции с точной сигнатурой:
    //   List<Order>  allOrders    — все заказы
    //   Queue<Order> pendingQueue — заказы, ожидающие обработки, в порядке поступления
    //   Stack<string> undoHistory — история последних действий для отмены
    // подсказка: для каждой коллекции создайте экземпляр прямо в поле,
    // например: private readonly Queue<Order> pendingQueue = new();
    private readonly List<Order> allOrders = new();
    private readonly Queue<Order> pendingQueue = new();
    private readonly Stack<string> undoHistory = new();

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
        // подсказка: описание удобно собрать так:
        // undoHistory.Push($"Создан заказ {order.Id} для {customerName}");
        undoHistory.Push($"Создан заказ {order.Id} для {customerName}");

        // ЗАДАЧА 5: верните созданный заказ
        return order;
    }

    public Order? ProcessNext()
    {
        // ЗАДАЧА 1: если pendingQueue пуст — верните null
        // подсказка: проверка emptiness — pendingQueue.Count == 0
        if (pendingQueue.Count == 0)
            return null;

        // ЗАДАЧА 2: извлеките заказ из очереди методом Dequeue (именно он, а не Peek)
        Order order = pendingQueue.Dequeue();

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
        string action = undoHistory.Pop();

        // ЗАДАЧА 3: выведите $"Отменено действие: {action}" и верните true
        Console.WriteLine($"Отменено действие: {action}");
        return true;
    }

    // ЗАДАЧА: допишите три метода-отчёта, используя foreach:
    //   PrintAllOrders()     — все заказы из allOrders по порядку добавления
    //   PrintPendingQueue()  — сколько заказов ждёт и какой первый в очереди (Peek, без извлечения)
    //   PrintRecentActions() — содержимое undoHistory (обход идёт от последнего к первому)
    public void PrintAllOrders()
    {
        Console.WriteLine($"Все заказы ({allOrders.Count}):");
        foreach (Order order in allOrders)
            Console.WriteLine($"  {order}");
    }

    public void PrintPendingQueue()
    {
        Console.WriteLine($"Ожидают обработки: {pendingQueue.Count}");
        if (pendingQueue.Count > 0)
            Console.WriteLine($"  Первый в очереди: {pendingQueue.Peek()}");

        foreach (Order order in pendingQueue)
            Console.WriteLine($"  {order}");
    }

    public void PrintRecentActions()
    {
        Console.WriteLine($"История действий ({undoHistory.Count}), от последнего к первому:");
        foreach (string action in undoHistory)
            Console.WriteLine($"  {action}");
    }

    // ===== Этап 2. КТ32: LinkedList<T> =====

    // ЗАДАЧА: объявите поле истории и узел текущего заказа:
    //   LinkedList<Order> orderHistory
    //   LinkedListNode<Order>? current
    // подсказка: узел nullable, поэтому тип поля с вопросительным знаком
    private readonly LinkedList<Order> orderHistory = new();
    private LinkedListNode<Order>? current;

    public void InitHistory(params Order[] orders)
    {
        // ЗАДАЧА 1: очистите историю (orderHistory.Clear())
        orderHistory.Clear();
        current = null;

        // ЗАДАЧА 2: добавьте заказы по очереди методом AddLast
        // ЗАДАЧА 3: сохраните в current узел последнего добавленного заказа
        // подсказка: AddLast возвращает узел — сохраняйте возвращённое значение,
        // тогда не придётся искать его через Find
        foreach (Order order in orders)
            current = orderHistory.AddLast(order);
    }

    public bool PlaceOrderAfterCurrent(Order order)
    {
        // ЗАДАЧА 1: добавьте новый заказ в историю через AddAfter(current, order)
        // подсказка: если current == null, сначала вызовите InitHistory или
        // сделайте AddLast и запомните узел — иначе AddAfter бросит ArgumentNullException
        // ЗАДАЧА 2: переставьте current на новый узел
        if (current is null)
            current = orderHistory.AddLast(order);
        else
            current = orderHistory.AddAfter(current, order);

        // ЗАДАЧА 3: верните true
        return true;
    }

    // Перемещение текущего узла на шаг назад по цепочке (через Previous),
    // чтобы показать, что AddAfter вставляет в середину, а не в конец.
    public bool MoveCurrentBack()
    {
        if (current?.Previous is null)
            return false;

        current = current.Previous;
        return true;
    }

    public bool TryFindOrder(string customerName, out Order? order)
    {
        // ЗАДАЧА: найдите узел через Find, проверьте его на null
        // подсказка: LINQ-расширение FirstOrDefault тоже подойдёт, но тема требует именно Find
        // Find у LinkedList ищет по значению (ссылке на заказ), поэтому сначала
        // берём заказы клиента из общего списка, затем ищем их узлы в истории.
        foreach (Order candidate in allOrders.FindAll(o => o.CustomerName == customerName))
        {
            LinkedListNode<Order>? node = orderHistory.Find(candidate);

            // ЗАДАЧА: если узел найден — запишите order = node.Value и верните true, иначе false
            if (node is not null)
            {
                order = node.Value;
                return true;
            }
        }

        order = null;
        return false;
    }

    public void PrintHistory()
    {
        // ЗАДАЧА: переберите историю через foreach и выведите каждый заказ
        Console.WriteLine($"История заказов ({orderHistory.Count}):");
        foreach (Order order in orderHistory)
        {
            string marker = ReferenceEquals(order, current?.Value) ? " <- текущий" : "";
            Console.WriteLine($"  {order}{marker}");
        }

        // ЗАДАЧА: отдельно выведите текущий заказ через current?.Value
        Console.WriteLine($"Текущий заказ: {current?.Value?.ToString() ?? "нет"}");
    }
}

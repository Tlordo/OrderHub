using OrderHub.Domain;
namespace OrderHub.Services;
public class OrderService
{
// ЗАДАЧА: объявите три коллекции с точной сигнатурой:
// List<Order> allOrders — все заказы
// Queue<Order> pendingQueue — заказы, ожидающие обработки,
в порядке поступления
// Stack<string> undoHistory — история последних действий
для отмены
// подсказка: для каждой коллекции создайте экземпляр прямо в
поле,
// например: private readonly Queue<Order> pendingQueue = new();
public Order CreateOrder(string customerName, string
productName, decimal price)
{
// ЗАДАЧА 1: создайте новый заказ (Id счётчик увеличивается
на 1)
// ЗАДАЧА 2: добавьте заказ в allOrders
// ЗАДАЧА 3: добавьте тот же заказ в pendingQueue методом
Enqueue
// ЗАДАЧА 4: запишите в undoHistory описание действия для
возможной отмены
// подсказка: описание удобно собрать так:
// undoHistory.Push($"Создан заказ {order.Id} для
{customerName}");
// ЗАДАЧА 5: верните созданный заказ
throw new NotImplementedException();
}
public Order? ProcessNext()
{
// ЗАДАЧА 1: если pendingQueue пуст — верните null
// подсказка: проверка emptiness — pendingQueue.Count == 0
// ЗАДАЧА 2: извлеките заказ из очереди методом Dequeue
(именно он, а не Peek)
// ЗАДАЧА 3: запишите в undoHistory, какой заказ обработан
// ЗАДАЧА 4: выведите в консоль $"Обработан заказ: {order}"
// ЗАДАЧА 5: верните обработанный заказ
throw new NotImplementedException();
}
public bool UndoLastAction()
{
// ЗАДАЧА 1: если undoHistory пуст — верните false
// ЗАДАЧА 2: извлеките последнее действие методом Pop
// ЗАДАЧА 3: выведите $"Отменено действие: {action}" и
верните true
throw new NotImplementedException();
}
// ЗАДАЧА: допишите три метода-отчёта, используя foreach:
// PrintAllOrders() — все заказы из allOrders по порядку
добавления
// PrintPendingQueue() — сколько заказов ждёт и какой первый в
очереди (Peek, без извлечения)
// PrintRecentActions() — содержимое undoHistory (обход идёт
от последнего к первому)
}

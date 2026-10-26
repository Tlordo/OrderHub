using System.Globalization;
using System.Text;
using OrderHub.Data;
using OrderHub.Domain;
using OrderHub.Services;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

Console.WriteLine("OrderHub — учёт заказов интернет-магазина");

// ===== Этап 1. КТ31: List<T>, Stack<T>, Queue<T> =====
Console.WriteLine();
Console.WriteLine("===== Этап 1. List, Queue, Stack =====");

var service = new OrderService();
service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);
service.ProcessNext();
service.ProcessNext();
service.PrintAllOrders();
service.PrintPendingQueue();
service.PrintRecentActions();
service.UndoLastAction();

// ===== Этап 2. КТ32: LinkedList<T> =====
Console.WriteLine();
Console.WriteLine("===== Этап 2. LinkedList =====");

var (c1, p1, pr1) = SeedData.HistoryOrders[0];
var (c2, p2, pr2) = SeedData.HistoryOrders[1];
var (c3, p3, pr3) = SeedData.HistoryOrders[2];
service.InitHistory(
    service.CreateOrder(c1, p1, pr1),
    service.CreateOrder(c2, p2, pr2),
    service.CreateOrder(c3, p3, pr3));
service.PrintHistory();

// текущий — последний; сдвигаемся на шаг назад, чтобы вставка была в середину
service.MoveCurrentBack();
Console.WriteLine("Текущий узел сдвинут назад через Previous.");

// ЗАДАЧА: вызовите PlaceOrderAfterCurrent с новым заказом и выведите историю
var (uc, up, upr) = SeedData.UrgentOrder;
service.PlaceOrderAfterCurrent(service.CreateOrder(uc, up, upr));
Console.WriteLine("После PlaceOrderAfterCurrent (AddAfter):");
service.PrintHistory();

// ЗАДАЧА: вызовите TryFindOrder("Иванов", out var found) и выведите результат
bool foundIvanov = service.TryFindOrder("Иванов", out Order? found);
Console.WriteLine($"TryFindOrder(\"Иванов\") = {foundIvanov}: {found}");

// ЗАДАЧА: вызовите TryFindOrder("Нет такого", out _) и убедитесь, что метод вернул false
bool foundMissing = service.TryFindOrder("Нет такого", out _);
Console.WriteLine($"TryFindOrder(\"Нет такого\") = {foundMissing}");

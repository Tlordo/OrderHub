using System.Globalization;
using System.Text;
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

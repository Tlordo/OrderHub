using System.Text;
using OrderHub.Services;

Console.OutputEncoding = Encoding.UTF8;

// ===== Этап 1. КТ 31: List<T>, Queue<T>, Stack<T> =====
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

Console.WriteLine();
service.UndoLastAction();

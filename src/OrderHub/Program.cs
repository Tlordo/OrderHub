using System.Text;
using OrderHub.Services;

Console.OutputEncoding = Encoding.UTF8;

var service = new OrderService();
service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);

service.ProcessNext();
service.ProcessNext();

service.PrintAllOrders();
service.PrintPendingQueue();
service.PrintRecentActions();
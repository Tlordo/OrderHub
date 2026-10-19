using System;
using OrderHub.Services;

var service = new OrderService();

// Создание заказов
service.CreateOrder("Иванов", "Клавиатура", 5490m);
service.CreateOrder("Петрова", "Монитор", 18990m);
service.CreateOrder("Сидоров", "Мышь", 1290m);

// Обработка первых двух заказов из очереди
service.ProcessNext();
service.ProcessNext();

// Вызов методов-отчетов
service.PrintAllOrders();
service.PrintPendingQueue();
service.PrintRecentActions();

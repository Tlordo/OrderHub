namespace OrderHub.Data;

// Начальные данные для демонстрации этапов.
public static class SeedData
{
    // Этап 2: заказы для истории клиента (клиент, товар, цена).
    public static readonly (string Customer, string Product, decimal Price)[] HistoryOrders =
    {
        ("Иванов", "Клавиатура", 5490m),
        ("Петрова", "Монитор", 18990m),
        ("Кузнецов", "Наушники", 7490m),
    };

    // Этап 2: заказ, который вставляется сразу после текущего.
    public static readonly (string Customer, string Product, decimal Price) UrgentOrder =
        ("Смирнова", "Веб-камера", 3990m);
}

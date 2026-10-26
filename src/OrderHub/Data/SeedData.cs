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

    // Этап 4 и далее: каталог товаров (название, цена, категория).
    public static readonly (string Name, decimal Price, string Category)[] Products =
    {
        ("Клавиатура", 5490m, "Периферия"),
        ("Монитор", 18990m, "Мониторы"),
        ("Мышь", 1290m, "Периферия"),
        ("Наушники", 7490m, "Аудио"),
        ("Веб-камера", 3990m, "Периферия"),
        ("Игровой монитор", 32990m, "Мониторы"),
        ("Колонки", 4590m, "Аудио"),
        ("Ноутбук", 74990m, "Компьютеры"),
    };
}

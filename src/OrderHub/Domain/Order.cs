using System.Globalization;

namespace OrderHub.Domain;

public class Order
{
    // ЗАДАЧА: объявите свойства только для чтения: Id, CustomerName, ProductName, Price, CreatedAt
    // подсказка: DateTime создаётся вызовом DateTime.Now, тип decimal — для денежных сумм
    public int Id { get; }
    public string CustomerName { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    // ЗАДАЧА: добавьте конструктор с параметрами Id, CustomerName, ProductName, Price, CreatedAt
    public Order(int id, string customerName, string productName, decimal price, DateTime createdAt)
    {
        Id = id;
        CustomerName = customerName;
        ProductName = productName;
        Price = price;
        CreatedAt = createdAt;
    }

    // ЗАДАЧА: переопределите ToString() так, чтобы вывод был вида
    // "#12 Иванов — Клавиатура 5 490,00 ₽ (12.03.2026)"
    // подсказка: используйте интерполяцию $"...", форматирование даты — d.ToString("dd.MM.yyyy")
    public override string ToString()
    {
        var ru = CultureInfo.GetCultureInfo("ru-RU");
        return $"#{Id} {CustomerName} — {ProductName} {Price.ToString("N2", ru)} ₽ ({CreatedAt.ToString("dd.MM.yyyy")})";
    }
}

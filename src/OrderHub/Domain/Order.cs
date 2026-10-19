namespace OrderHub.Domain;
public class Order
{
// ЗАДАЧА: добавьте конструктор с параметрами Id, CustomerName,
ProductName, Price, CreatedAt
// ЗАДАЧА: объявите свойства только для чтения: Id,
CustomerName, ProductName, Price, CreatedAt
// подсказка: DateTime создаётся вызовом DateTime.Now, тип
decimal — для денежных сумм
// ЗАДАЧА: переопределите ToString() так, чтобы вывод был вида
// "#12 Иванов — Клавиатура 5 490,00 ₽ (12.03.2026)"
// подсказка: используйте интерполяцию $"...", форматирование
даты — d.ToString("dd.MM.yyyy")
}


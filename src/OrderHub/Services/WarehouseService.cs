using System.Collections.Generic;

namespace OrderHub.Services;

public class WarehouseService
{
    // ЗАДАЧА: объявите Dictionary<string, int> stock — название товара → количество
    // подсказка: поле инициализируется прямо при объявлении: = new Dictionary<string, int>();
    private readonly Dictionary<string, int> stock = new Dictionary<string, int>();

    public void Receive(string productName, int quantity)
    {
        // ЗАДАЧА 1: проверьте наличие товара через TryGetValue
        if (stock.TryGetValue(productName, out int existing))
        {
            // ЗАДАЧА 2: если товар есть — увеличьте количество (stock[productName] = existing + quantity)
            stock[productName] = existing + quantity;
        }
        else
        {
            // ЗАДАЧА 3: если товара нет — добавьте новую запись через индексатор
            stock[productName] = quantity;
        }

        // ЗАДАЧА 4: выведите итоговое количество товара на складе
        Console.WriteLine($"Поступление: {productName} +{quantity}, на складе {stock[productName]} шт.");
    }

    public bool Sell(string productName, int quantity)
    {
        // ЗАДАЧА 1: если товара нет вообще — сообщите об этом и верните false
        //           (никаких исключений: используйте TryGetValue)
        if (!stock.TryGetValue(productName, out int available))
        {
            Console.WriteLine($"Продажа: товара «{productName}» нет на складе.");
            return false;
        }

        // ЗАДАЧА 2: если товара недостаточно — выведите предупреждение и верните false
        if (available < quantity)
        {
            Console.WriteLine($"Предупреждение: «{productName}» недостаточно (запрошено {quantity}, есть {available}).");
            return false;
        }

        // ЗАДАЧА 3: уменьшите остаток на quantity
        int left = available - quantity;
        stock[productName] = left;
        Console.WriteLine($"Продажа: {productName} -{quantity}, осталось {left} шт.");

        // ЗАДАЧА 4: если остаток стал равен нулю — удалите запись через Remove
        //           и сообщите, что товар снят с учёта
        if (left == 0 && stock.Remove(productName))
            Console.WriteLine($"Товар «{productName}» закончился и снят с учёта.");

        // ЗАДАЧА 5: верните true
        return true;
    }

    public bool TryGetStock(string productName, out int quantity)
    {
        // ЗАДАЧА: реализуйте безопасный поиск остатка через TryGetValue
        // ЗАДАЧА: при отсутствии товара присвойте quantity = 0 — значение по умолчанию,
        //         чтобы у вызывающего кода не было неинициализированной переменной
        if (stock.TryGetValue(productName, out quantity))
            return true;

        quantity = 0;
        return false;
    }

    public void PrintStock()
    {
        // ЗАДАЧА: переберите склад через foreach по KeyValuePair<string, int>
        // ЗАДАЧА: отсортируйте вывод по алфавиту (OrderBy можно использовать уже сейчас)
        Console.WriteLine($"Склад, позиций: {stock.Count}");
        foreach (KeyValuePair<string, int> pair in stock.OrderBy(p => p.Key))
            Console.WriteLine($"  {pair.Key}: {pair.Value} шт.");
    }
}

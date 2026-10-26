using System.Collections.Generic;
using OrderHub.Domain;

namespace OrderHub.Services;

public class CatalogService
{
    private readonly List<Product> products = new();

    // исходный порядок добавления — Sort() меняет products на месте, поэтому храним его отдельно
    private readonly List<Product> originalOrder = new();

    public void AddProduct(string name, decimal price, string category)
    {
        // ЗАДАЧА: добавьте товар в список products
        var product = new Product(name, price, category);
        products.Add(product);
        originalOrder.Add(product);
    }

    public void PrintSortedByNaturalOrder()
    {
        // ЗАДАЧА 1: вызовите Sort() без аргументов — сработает IComparable<Product>
        products.Sort();

        // ЗАДАЧА 2: выведите каждый товар через foreach
        Console.WriteLine("Каталог по цене (IComparable<Product>, Sort()):");
        foreach (Product product in products)
            Console.WriteLine($"  {product}");
    }

    public void PrintSortedByName()
    {
        // ЗАДАЧА: вызовите Sort(new NameComparer())
        products.Sort(new NameComparer());

        // ЗАДАЧА: выведите результат
        Console.WriteLine("Каталог по названию (IComparer<Product>, NameComparer):");
        foreach (Product product in products)
            Console.WriteLine($"  {product}");
    }

    public void PrintSortedByPriceDesc()
    {
        products.Sort(new PriceDescComparer());

        Console.WriteLine("Каталог по убыванию цены (IComparer<Product>, PriceDescComparer):");
        foreach (Product product in products)
            Console.WriteLine($"  {product}");
    }

    public void PrintSortedByNameLength()
    {
        // ЗАДАЧА: отсортируйте лямбдой по длине названия —
        //   Sort((a, b) => a.Name.Length.CompareTo(b.Name.Length));
        // это делегат Comparison<Product>
        products.Sort((a, b) => a.Name.Length.CompareTo(b.Name.Length));

        // ЗАДАЧА: выведите результат и поясните в консоли, что тип Product не менялся
        Console.WriteLine("Каталог по длине названия (лямбда Comparison<Product>):");
        foreach (Product product in products)
            Console.WriteLine($"  {product} [длина {product.Name.Length}]");
        Console.WriteLine("  Класс Product не менялся: разовый порядок передан лямбдой в Sort.");
    }

    // ЗАДАЧА: добавьте метод PrintAll(), который печатает каталог в исходном порядке
    public void PrintAll()
    {
        Console.WriteLine("Каталог в исходном порядке:");
        foreach (Product product in originalOrder)
            Console.WriteLine($"  {product}");
    }
}

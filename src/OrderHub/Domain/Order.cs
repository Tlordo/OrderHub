namespace OrderHub.Domain;

public class Order
{
    public int Id { get; }
    public string CustomerName { get; }
    public string ProductName { get; }
    public decimal Price { get; }
    public DateTime CreatedAt { get; }

    public Order(int id, string customerName, string productName, decimal price, DateTime createdAt)
    {
        Id = id;
        CustomerName = customerName;
        ProductName = productName;
        Price = price;
        CreatedAt = createdAt;
    }

    public override string ToString()
    {
        return $"#{Id} {CustomerName} — {ProductName} {Price:N2} ₽ ({CreatedAt:dd.MM.yyyy})";
    }
}

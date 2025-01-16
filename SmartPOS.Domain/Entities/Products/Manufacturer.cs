namespace SmartPOS.Domain.Entities.Products;

public class Manufacturer : Entity, IAggregateRoot
{
    public string Name { get; private set; }
    public HashSet<Product> Products { get; private set; } = [];
}

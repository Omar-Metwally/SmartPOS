namespace SmartPOS.Domain.Entities.Products;

public class UnitOfMeasure : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
}

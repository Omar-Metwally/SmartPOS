
namespace SmartPOS.Domain.Entities.Products;

public class Attribute : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public HashSet<AttributeValue> AttributeValues { get; private set; } = [];
}
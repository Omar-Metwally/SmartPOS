
namespace SmartPOS.Domain.Entities.Products;

public class AttributeValue : Entity
{
    public int AttributeId { get; private set; }
    public string Value { get; private set; } = null!;
}

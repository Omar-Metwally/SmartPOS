using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Products;

public class ProductInstance : Entity
{
    public int ProductId { get; private set; }
    public string? Sku { get; private set; }
    public int? DefaultQuantityAlertLevel { get; private set; }
    public virtual Product Product { get; private set; } = null!;
    public HashSet<Image> Images { get; private set; } = [];
    public HashSet<ProductInstanceAttributeValue> AttributeValues { get; private set; } = [];
    public HashSet<ProductInstancePrice> Prices { get; private set; } = [];
}
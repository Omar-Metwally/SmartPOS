using SmartPOS.Domain.Entities.Inventory;

namespace SmartPOS.Domain.Entities.Products;

public class ProductInstancePrice
{
    public int ProductInstanceId { get; private set; }
    public int UnitOfMeasureId { get; private set; }
    public decimal SellingPrice { get; private set; }
    public virtual ProductInstance ProductInstance { get; private set; } = null!;
    public virtual UnitOfMeasure UnitOfMeasure { get; private set; } = null!;
    public HashSet<SerializedUnit> SerializedUnits { get; private set; } = [];
}
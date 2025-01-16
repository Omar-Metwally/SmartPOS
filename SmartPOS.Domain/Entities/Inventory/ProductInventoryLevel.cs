using SmartPOS.Domain.Entities.Inventory;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.Entities.Products;

namespace SmartPOS.Domain.Entities.Accounting;

public class ProductInventoryLevel : Entity, IAggregateRoot
{
    public int ProductInstanceId { get; private set; }
    public int UnitOfMeasureId { get; private set; }
    public int WarehouseId { get; private set; }
    public int Quantity { get; private set; }
    public virtual Warehouse Warehouse { get; private set; } = null!;
    public virtual ProductInstancePrice ProductInstance { get; private set; } = null!;
    public HashSet<ProductLevelChange> Changes { get; private set; } = [];
    public HashSet<SerializedUnit> SerializedUnits { get; private set; } = [];
}

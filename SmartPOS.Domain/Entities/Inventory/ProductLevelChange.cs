using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Domain.Entities.Inventory;

public class ProductLevelChange : Entity
{
    public int ProductInventoryLevelId { get; private set; }
    public int WarehouseId { get; private set; }
    public int? TransactionId { get; private set; }
    public DateTime ChangeDate { get; private set; }
    public TransactionType ChangeType { get; private set; }
    public int PreviousQuantity { get; private set; }
    public int ChangedQuantity { get; private set; }
    public int NewQuantity { get; private set; }
    //public virtual ProductInventoryLevel ProductInventoryLevel { get; private set; } = null!;
    public virtual InventoryTransaction? Transaction { get; private set; }
    public HashSet<SerialUnitChange> StatusChanges { get; private set; } = [];

    public void AddSerialUnitChange(SerializedUnit unit, int? oldWarehouseId)
    {
        var change = SerialUnitChange.CreateFromBulkMovement(
            unit.Id,
            unit.Status,
            WarehouseId,
            oldWarehouseId,
            Id);

        StatusChanges.Add(change);
    }
}

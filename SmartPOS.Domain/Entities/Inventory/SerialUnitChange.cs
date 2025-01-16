using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.Entities.Transactions;

namespace SmartPOS.Domain.Entities.Inventory;

public class SerialUnitChange : Entity
{
    public int SerializedUnitId { get; private set; }
    public SerialUnitStatus Status { get; private set; }
    public DateTime ChangeDate { get; private set; }
    public int? OldWarehouseId { get; private set; }
    public int? NewWarehouseId { get; private set; }
    public int? ProductLevelChangeId { get; private set; }
    public virtual SerializedUnit SerializedUnit { get; private set; } = null!;
    public virtual ProductLevelChange? ProductLevelChange { get; private set; }
    public virtual Warehouse? OldWarehouse { get; private set; }
    public virtual Warehouse? NewWarehouse { get; private set; }

    private SerialUnitChange(
        int serializedUnitId,
        SerialUnitStatus status,
        int? newWarehouseId,
        int? oldWarehouseId = null,
        int? productLevelChangeId = null)
    {
        SerializedUnitId = serializedUnitId;
        Status = status;
        ChangeDate = DateTime.UtcNow;
        NewWarehouseId = newWarehouseId;
        OldWarehouseId = oldWarehouseId;
        ProductLevelChangeId = productLevelChangeId;
    }

    public static SerialUnitChange CreateFromBulkMovement(
        int serializedUnitId,
        SerialUnitStatus status,
        int? newWarehouseId,
        int? oldWarehouseId,
        int productLevelChangeId)
    {
        return new SerialUnitChange(
            serializedUnitId,
            status,
            newWarehouseId,
            oldWarehouseId,
            productLevelChangeId);
    }

    public static SerialUnitChange CreateFromIndividualChange(
        int serializedUnitId,
        SerialUnitStatus status,
        int? newWarehouseId,
        int? oldWarehouseId = null)
    {
        return new SerialUnitChange(
            serializedUnitId,
            status,
            newWarehouseId,
            oldWarehouseId);
    }
}
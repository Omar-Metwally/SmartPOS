using SmartPOS.Common.Enums;
using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Products;

namespace SmartPOS.Domain.Entities.Inventory;

public class SerializedUnit : Entity, IAggregateRoot
{
    public int ProductInstanceId { get; private set; }
    public int UnitOfMeasureId { get; private set; }
    public int ProductInventoryLevelId { get; private set; }
    public string SerialNumber { get; private set; } = null!;
    public int? WarehouseId { get; private set; }
    public SerialUnitStatus Status { get; private set; }
    public ProductInstancePrice Product { get; private set; } = null!;
    public HashSet<SerialUnitChange> StatusChanges { get; private set; } = [];

    private SerializedUnit(int productInstanceId, int unitOfMeasureId, string serialNumber)
    {
        ProductInstanceId = productInstanceId;
        SerialNumber = serialNumber;
        Status = SerialUnitStatus.Available;
    }

    private SerializedUnit() { }

    public static IResult<SerializedUnit> Create(int productInstanceId, int unitOfMeasureId, string serialNumber)
    {
        var result = new Result<SerializedUnit>();

        if (productInstanceId < 1)
            return result.WithBadRequest("Invalid product instance ID");

        if (unitOfMeasureId < 1)
            return result.WithBadRequest("Invalid unit measure ID");

        if (string.IsNullOrWhiteSpace(serialNumber))
            return result.WithBadRequest("Serial number cannot be empty");

        var unit = new SerializedUnit(productInstanceId, unitOfMeasureId, serialNumber);
        return result.WithValue(unit);
    }

    public IResult UpdateLocation(int? warehouseId)
    {
        if (warehouseId.HasValue && warehouseId.Value < 1)
            return new Result().WithBadRequest("Invalid warehouse ID");

        var oldWarehouseId = WarehouseId;
        WarehouseId = warehouseId;

        var change = SerialUnitChange.CreateFromIndividualChange(
            Id,
            Status,
            warehouseId,
            oldWarehouseId);

        StatusChanges.Add(change);
        return new Result();
    }

    public IResult MarkAsSold()
    {
        if (Status == SerialUnitStatus.Sold)
            return new Result().WithBadRequest("Unit is already marked as sold");

        var oldWarehouseId = WarehouseId;
        Status = SerialUnitStatus.Sold;
        WarehouseId = null;

        var change = SerialUnitChange.CreateFromIndividualChange(
            Id,
            Status,
            WarehouseId,
            oldWarehouseId);

        StatusChanges.Add(change);
        return new Result();
    }
}
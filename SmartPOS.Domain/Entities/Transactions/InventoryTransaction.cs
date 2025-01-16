using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Domain.Entities.Transactions;

public abstract class InventoryTransaction : Transaction
{
    public int WarehouseId { get; private set; }
    public virtual decimal Total => Items.Sum(item => item.Total);
    public virtual Warehouse Warehouse { get; private set; } = null!;
    public HashSet<InventoryTransactionItem> Items { get; private set; } = [];

    protected static IResult ValidateInventoryTransactionBaseDetails(int branchId, int warehouseId)
    {
        var transactionBaseDateResult = ValidateTransactionBaseData(branchId);
        if (transactionBaseDateResult.IsFailed)
            return transactionBaseDateResult;

        if (warehouseId < 1)
            return new Result().WithBadRequest("Please reselect the warehouse and try again");

        return transactionBaseDateResult;
    }

    protected InventoryTransaction(int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(branchId, date, note)
    {
        WarehouseId = warehouseId;
    }

    protected InventoryTransaction() { }

    public IResult UpdateWarehouse(int warehouseId)
    {
        if (warehouseId < 1)
            return new Result().WithBadRequest("Please reselect the warehouse and try again");

        WarehouseId = warehouseId;
        return new Result();
    }
}
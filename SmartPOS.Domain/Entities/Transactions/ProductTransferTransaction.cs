using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Domain.Entities.Transactions;

public class ProductTransferTransaction : InventoryTransaction
{
    private ProductTransferTransaction(int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(warehouseId, branchId, date, note)
    {
    }
    
    private ProductTransferTransaction() { }

    public int ReceivingWarehouseId { get; private set; }
    public Warehouse ReceivingWarehouse { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.ProductTransfer;
    }
}
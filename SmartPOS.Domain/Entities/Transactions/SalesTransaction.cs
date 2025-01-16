using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public abstract class SalesTransaction : ExternalEntityInventoryTransaction
{
    public DeliveryDetails DeliveryDetails { get; private set; } = null!;
    public override decimal Total => Items.Sum(item => item.Total);
    public new HashSet<SalesTransactionItem> Items { get; private set; } = [];

    protected SalesTransaction(int safeId, Payment payment, int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(payment, safeId, warehouseId, branchId, date, note)
    {
    }

    protected SalesTransaction() { }
}

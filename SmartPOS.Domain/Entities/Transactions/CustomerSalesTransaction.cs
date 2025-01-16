using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class CustomerSalesTransaction : SalesTransaction
{
    public int CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.CustomerSales;
    }

    public CustomerSalesTransaction(int safeId, Payment payment, int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(safeId, payment, warehouseId, branchId, date, note)
    {
    }

    private CustomerSalesTransaction() { }
}

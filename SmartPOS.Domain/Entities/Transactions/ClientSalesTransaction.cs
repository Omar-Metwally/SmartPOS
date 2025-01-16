using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class ClientSalesTransaction : SalesTransaction
{
    private ClientSalesTransaction(int safeId, Payment payment, int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(safeId, payment, warehouseId, branchId, date, note)
    {
    }

    private ClientSalesTransaction() { }

    public int ClientId { get; private set; }
    public Client Client { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.ClientSales;
    }
}

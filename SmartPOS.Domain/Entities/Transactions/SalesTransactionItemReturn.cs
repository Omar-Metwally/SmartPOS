namespace SmartPOS.Domain.Entities.Transactions;

public class SalesTransactionItemReturn : InventoryTransactionItemReturn
{
    public decimal UnitPrice { get; private set; }
}

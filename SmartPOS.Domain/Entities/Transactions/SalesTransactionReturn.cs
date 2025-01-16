namespace SmartPOS.Domain.Entities.Transactions;

public class SalesTransactionReturn : ExternalEntityInventoryTransactionReturn
{
    public new HashSet<SalesTransactionItemReturn> ReturnedItems { get; private set; } = [];

    private SalesTransactionReturn() { }
}

using SmartPOS.Common.Results;

namespace SmartPOS.Domain.Entities.Transactions;

public class InventoryTransactionItemReturn
{
    public int ReturnTransactionId { get; private set; }
    public int InventoryTransactionItemId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitCost { get; private set; }

    protected InventoryTransactionItemReturn() {}

    protected InventoryTransactionItemReturn(int returnTransactionId, int inventoryTransactionItemId, int quantity, decimal unitCost)
    {
        ReturnTransactionId = returnTransactionId;
        InventoryTransactionItemId = inventoryTransactionItemId;
        Quantity = quantity;
        UnitCost = unitCost;
    }

    public static IResult<InventoryTransactionItemReturn> Create(int returnTransactionId, int inventoryTransactionItemId, int quantity, decimal unitCost)
    {
        var result = new Result<InventoryTransactionItemReturn>();

        if (returnTransactionId < 1)
            return result.WithBadRequest("Invalid inventory transaction ID");

        if (inventoryTransactionItemId < 1)
            return result.WithBadRequest("Invalid transaction item ID");

        if (quantity < 1)
            return result.WithBadRequest("Quantity must be greater than zero");

        if (unitCost <= 0)
            return result.WithBadRequest("Unit cost must be greater than zero");

        var itemReturn = new InventoryTransactionItemReturn(returnTransactionId, inventoryTransactionItemId, quantity, unitCost);

        return result.WithValue(itemReturn);
    }
}

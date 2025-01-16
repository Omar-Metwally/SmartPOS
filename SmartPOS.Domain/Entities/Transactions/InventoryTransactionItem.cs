using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Products;

namespace SmartPOS.Domain.Entities.Transactions;

public class InventoryTransactionItem : Entity
{
    public int InventoryTransactionId { get; private set; }
    public int ProductInstanceId { get; private set; }
    public int UnitOfMeasureID { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitCost { get; private set; }
    public virtual decimal Total => Quantity * UnitCost;
    public virtual ProductInstancePrice Unit { get; private set; } = null!;

    protected InventoryTransactionItem(int inventoryTransactionId, int productInstanceId, int unitOfMeasureID, int quantity, decimal unitCost)
    {
        InventoryTransactionId = inventoryTransactionId;
        ProductInstanceId = productInstanceId;
        UnitOfMeasureID = unitOfMeasureID;
        Quantity = quantity;
        UnitCost = unitCost;
    }

    public static IResult<InventoryTransactionItem> CreateItem(
        int inventoryTransactionId,
        int productInstanceId,
        int unitOfMeasureId,
        int quantity,
        decimal unitCost)
    {
        var result = new Result<InventoryTransactionItem>();

        if (inventoryTransactionId < 1)
            return result.WithBadRequest("Invalid inventory transaction ID");
        if (productInstanceId < 1)
            return result.WithBadRequest("Invalid product instance ID");
        if (unitOfMeasureId < 1)
            return result.WithBadRequest("Invalid unit of measure ID");
        if (quantity < 1)
            return result.WithBadRequest("Quantity must be greater than zero");
        if (unitCost <= 0)
            return result.WithBadRequest("Unit cost must be greater than zero");

        var item = new InventoryTransactionItem(inventoryTransactionId, productInstanceId, unitOfMeasureId, quantity, unitCost);
        return result.WithValue(item);
    }
}
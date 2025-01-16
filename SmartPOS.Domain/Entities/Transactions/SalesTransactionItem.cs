using SmartPOS.Common.Results;

namespace SmartPOS.Domain.Entities.Transactions;

public class SalesTransactionItem : InventoryTransactionItem
{
    public int DiscountPercentage { get; private set; }
    public decimal UnitPriceBeforeDiscount { get; private set; }
    public decimal UnitPriceAfterDiscount => UnitPriceBeforeDiscount * (1 - (DiscountPercentage / 100m));
    public override decimal Total => UnitPriceAfterDiscount * Quantity;

    private SalesTransactionItem(decimal unitPriceBeforeDiscount, int discountPercentage, int inventoryTransactionId, int productInstanceId, int unitOfMeasureID, int quantity, decimal unitCost)
        : base(inventoryTransactionId, productInstanceId, unitOfMeasureID, quantity, unitCost)
    {
        DiscountPercentage = discountPercentage;
        UnitPriceBeforeDiscount = unitPriceBeforeDiscount;
    }

    public static IResult<SalesTransactionItem> Create(
        int inventoryTransactionId,
        int productInstanceId,
        int unitOfMeasureId,
        int quantity,
        decimal unitCost,
        int discountPercentage,
        decimal unitPriceBeforeDiscount)
    {
        var result = new Result<SalesTransactionItem>();

        var baseResult = CreateItem(inventoryTransactionId, productInstanceId, unitOfMeasureId, quantity, unitCost);
        if (baseResult.IsFailed)
            return result
                .WithErrors(baseResult.Errors)
                .WithStatusCode(baseResult.StatusCode)
                .WithMessage(baseResult.Message);

        if (discountPercentage < 0 || discountPercentage > 100)
            return result.WithBadRequest("Discount percentage must be between 0 and 100");
        if (unitPriceBeforeDiscount <= 0)
            return result.WithBadRequest("Unit price before discount must be greater than zero");

        var salesItem = new SalesTransactionItem(
            unitPriceBeforeDiscount,
            discountPercentage,
            inventoryTransactionId,
            productInstanceId,
            unitOfMeasureId,
            quantity,
            unitCost);

        return result.WithValue(salesItem);
    }
}
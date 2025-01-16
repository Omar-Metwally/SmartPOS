using SmartPOS.Common.Enums;
using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class PurchaseTransaction : ExternalEntityInventoryTransaction
{
    public int SupplierId { get; private set; }
    public Supplier Supplier { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.Purchase;
    }

    private PurchaseTransaction(int supplierId, Payment payment, int safeId, int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(payment, safeId, warehouseId, branchId, date, note)
    {
        SupplierId = supplierId;
    }

    private PurchaseTransaction() { }

    public static IResult<PurchaseTransaction> Create(int supplierId, int branchId, int warehouseId, int safeId, decimal payedAmount, string paymentType, string? note = default, DateTime? date = null)
    {
        var result = new Result<PurchaseTransaction>();

        if (supplierId < 1)
            return result.WithBadRequest("Please reselect the supplier and try again");

        var externalEntityInventoryTransactionResult = ValidateExternalEntityInventoryTransactionBaseDate(branchId, warehouseId, safeId, payedAmount, paymentType, note);
        if (externalEntityInventoryTransactionResult.IsFailed)
            return result
                .WithErrors(externalEntityInventoryTransactionResult.Errors)
                .WithStatusCode(externalEntityInventoryTransactionResult.StatusCode)
                .WithMessage(externalEntityInventoryTransactionResult.Message);

        var paymentResult = Payment.Create(payedAmount, paymentType);
        if (paymentResult.IsFailed)
            return result
                .WithErrors(externalEntityInventoryTransactionResult.Errors)
                .WithStatusCode(externalEntityInventoryTransactionResult.StatusCode)
                .WithMessage(externalEntityInventoryTransactionResult.Message);

        var newPurchaseTransaction = new PurchaseTransaction(supplierId, paymentResult.Value, safeId, warehouseId, branchId, date, note);

        return result.WithValue(newPurchaseTransaction);
    }

    public IResult UpdateSupplier(int supplierId)
    {
        if (supplierId < 1)
            return new Result().WithBadRequest("Please reselect the supplier and try again");

        SupplierId = supplierId;
        return new Result();
    }
}

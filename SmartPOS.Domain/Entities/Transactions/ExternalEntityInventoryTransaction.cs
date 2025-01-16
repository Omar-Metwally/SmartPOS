using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public abstract class ExternalEntityInventoryTransaction : InventoryTransaction
{
    protected ExternalEntityInventoryTransaction(Payment payment, int safeId, int warehouseId, int branchId, DateTime? date = null, string? note = null) : base(warehouseId, branchId, date, note)
    {
        SafeId = safeId;
        Payment = payment;
    }

    protected ExternalEntityInventoryTransaction() { }

    public int SafeId { get; private set; }
    public virtual Safe Safe { get; private set; } = null!;
    public Payment? Payment { get; private set; }
    public HashSet<ExternalEntityInventoryTransactionReturn> Returns { get; private set; } = [];

    protected static IResult ValidateExternalEntityInventoryTransactionBaseDate(int branchId, int warehouseId, int safeId, decimal payedAmount, string paymentType, string? comment = default)
    {
        var externalEntityInventoryTransactionResult = ValidateInventoryTransactionBaseDetails(branchId, warehouseId);
        if (externalEntityInventoryTransactionResult.IsFailed)
            return externalEntityInventoryTransactionResult;

        if (safeId < 1)
            return new Result().WithBadRequest("Please reselect the safe and try again");

        var paymentResult = Payment.ValidatePaymentData(payedAmount, paymentType);
        if (paymentResult.IsFailed)
            return paymentResult;

        return externalEntityInventoryTransactionResult;
    }

    public IResult UpdateSafe(int safeId)
    {
        if (safeId < 1)
            return new Result().WithBadRequest("Please reselect the safe and try again");

        SafeId = safeId;
        return new Result();
    }
}
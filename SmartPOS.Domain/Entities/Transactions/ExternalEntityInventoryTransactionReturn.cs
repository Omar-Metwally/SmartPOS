using SmartPOS.Common.Results;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class ExternalEntityInventoryTransactionReturn : Entity
{
    public int TransactionId { get; private set; }
    public DateTime Date { get; private set; }
    public Payment? Payment { get; private set; }
    public string Note { get; private set; } = string.Empty;
    public HashSet<InventoryTransactionItemReturn> ReturnedItems { get; private set; } = [];

    protected ExternalEntityInventoryTransactionReturn(int transactionId, DateTime? date = default, Payment? payment = default, string? note = default)
    {
        TransactionId = transactionId;
        Date = date ?? DateTime.UtcNow;
        Payment = payment;
        Note = note ?? string.Empty;
    }

    protected ExternalEntityInventoryTransactionReturn() { }

    public static IResult<ExternalEntityInventoryTransactionReturn> Create(int transactionId, DateTime? date = default, decimal? payedAmount = default, string? paymentType = default)
    {
        var result = new Result<ExternalEntityInventoryTransactionReturn>();

        if (transactionId < 1)
            return result.WithBadRequest("Please reselect the safe and try again");

        if (payedAmount.HasValue && !string.IsNullOrWhiteSpace(paymentType))
        {
            var paymentResult = Payment.Create(payedAmount.Value, paymentType);
            if (paymentResult.IsFailed)
                result
                .WithErrors(paymentResult.Errors)
                .WithStatusCode(paymentResult.StatusCode)
                .WithMessage(paymentResult.Message);

            var item = new ExternalEntityInventoryTransactionReturn(transactionId, date, paymentResult.Value);
            return result.WithValue(item);
        }
        else
        {
            var item = new ExternalEntityInventoryTransactionReturn(transactionId, date);
            return result.WithValue(item);
        }
    }
}

using SmartPOS.Common.Enums;
using SmartPOS.Common.Results;

namespace SmartPOS.Domain.ValueObjects;

public class Payment : ValueObject
{
    public decimal PayedAmount { get; private set; }
    public PaymentType Type { get; private set; }
    public string Comment { get; private set; } = string.Empty;

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return PayedAmount;
        yield return Type;
        yield return Comment;
    }

    public static IResult<Payment> Create(decimal payedAmount, string paymentType, string? comment = default)
    {
        var result = new Result<Payment>();

        if (payedAmount < 1)
            return result.WithBadRequest("Payed amount can be less than 1.");

        var paymentTypeResult = ParsePaymentType(paymentType);
        if (paymentTypeResult.IsFailed)
            return result.WithErrors(paymentTypeResult.Errors);

        var payment = new Payment
        {
            PayedAmount = payedAmount,
            Type = paymentTypeResult.Value,
            Comment = comment ?? string.Empty
        };

        return result.WithValue(payment);
    }

    public static IResult ValidatePaymentData(decimal payedAmount, string paymentType)
    {
        if (payedAmount < 1)
            return new Result().WithBadRequest("Payed amount can be less than 1.");

        var paymentTypeResult = ParsePaymentType(paymentType);
        if (paymentTypeResult.IsFailed)
            return paymentTypeResult.WithErrors(paymentTypeResult.Errors);

        return paymentTypeResult;
    }

    public static IResult<PaymentType> ParsePaymentType(string paymentType)
    {
        var result = new Result<PaymentType>();

        if (string.IsNullOrWhiteSpace(paymentType))
            return result.WithBadRequest("Payment type cannot be empty.");

        paymentType = paymentType.Trim();

        if (Enum.TryParse(paymentType, ignoreCase: true, out PaymentType type))
        {
            if (type == PaymentType.Unknown)
                return result.WithBadRequest("Invalid payment type.");

            return result.WithValue(type);
        }

        return result.WithBadRequest($"Invalid payment type: {paymentType}. Valid types are: {string.Join(", ", Enum.GetNames(typeof(PaymentType)).Where(n => n != "Unknown"))}");
    }
}

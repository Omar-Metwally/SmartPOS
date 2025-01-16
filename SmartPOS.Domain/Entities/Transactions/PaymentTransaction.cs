using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.ExternalEntities;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class PaymentTransaction : Transaction
{
    public int PartyId { get; private set; }
    public int SafeId { get; private set; }
    public Payment Payment { get; private set; } = null!;
    public ExternalParty Party { get; private set; } = null!;
    public Safe Safe { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.Payment;
    }

    private PaymentTransaction(int branchId, DateTime? date = null, string? note = null) : base(branchId, date, note)
    {
    }

    private PaymentTransaction() { }
}
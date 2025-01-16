using SmartPOS.Common.Enums;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Transactions;

public class SafeTransferTransaction : Transaction
{
    private SafeTransferTransaction(int branchId, DateTime? date = null, string? note = null) : base(branchId, date, note)
    {
    }

    private SafeTransferTransaction() {}

    public int SafeId { get; private set; }
    public Safe Safe { get; private set; } = null!;
    public int ReceivingSafeId { get; private set; }
    public Safe ReceivingSafe { get; private set; } = null!;
    public Payment Payment { get; private set; } = null!;

    public override TransactionType GetTransactionType()
    {
        return TransactionType.SafeTransfer;
    }
}


using SmartPOS.Common.Enums;
using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Organization;

namespace SmartPOS.Domain.Entities.Transactions;

public abstract class Transaction : Entity, IAggregateRoot
{
    public DateTime Date { get; private set; }
    public int BranchId { get; private set; }
    public virtual Branch Branch { get; private set; } = null!;
    public string Note { get; private set; } = string.Empty;

    public abstract TransactionType GetTransactionType();

    protected Transaction(int branchId, DateTime? date = default, string? note = default)
    {
        Date = date ?? DateTime.UtcNow;
        BranchId = branchId;
        Note = note ?? string.Empty;
    }

    protected Transaction() { }

    protected static IResult ValidateTransactionBaseData(int branchId)
    {
        if (branchId < 1)
            return new Result().WithBadRequest("Please reselect the branch and try again");

        return new Result();
    }

    public IResult UpdateBranch(int branchId)
    {
        if (branchId < 1)
            return new Result().WithBadRequest("Please reselect the branch and try again");

        BranchId = branchId;
        return new Result();
    }

    public IResult UpdateDate(DateTime date)
    {
        Date = date;
        return new Result();
    }
}

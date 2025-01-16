using SmartPOS.Domain.Entities.HR;
using SmartPOS.Domain.Entities.Organization;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Users;

public class Employee : Entity
{
    public int BranchId { get; private set; }
    public int JobId { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string NationalId { get; private set; } = null!;
    public DateOnly BirthDate { get; private set; }
    public decimal Bonus { get; private set; }
    public Address? Address { get; private set; }
    public virtual Branch Branch { get; private set; } = null!;
    public virtual Job Job { get; private set; } = null!;
}

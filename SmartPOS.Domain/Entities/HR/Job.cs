namespace SmartPOS.Domain.Entities.HR;

public class Job : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public decimal BaseSalary { get; private set; }
}

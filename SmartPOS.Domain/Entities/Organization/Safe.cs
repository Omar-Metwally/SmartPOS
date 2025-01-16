namespace SmartPOS.Domain.Entities.Organization;

public class Safe : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public decimal CashStartBalance { get; private set; }
    public decimal VISAStartBalance { get; private set; }
    public decimal ChequeStartBalance { get; private set; }
}

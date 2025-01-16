using SmartPOS.Domain.Entities.Users;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Organization;

public class Warehouse : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
}
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.ExternalEntities;

public class ExternalCompany : ExternalParty, IAggregateRoot
{
    public HashSet<ContactPerson> Contacts { get; private set; } = [];
    public HashSet<Address> Addresses { get; private set; } = [];
}

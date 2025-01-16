using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.ExternalEntities;

public class Customer : ExternalParty
{
    public string? Comment { get; private set; }
    public PhoneNumber? PhoneNumber { get; private set; }
    public Address? Address { get; private set; }
}

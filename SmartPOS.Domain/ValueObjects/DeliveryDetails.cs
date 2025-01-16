
namespace SmartPOS.Domain.ValueObjects;

public class DeliveryDetails : ValueObject
{
    public Address Address { get; private set; } = null!;
    public PhoneNumber? PhoneNumber { get; private set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
    }
}

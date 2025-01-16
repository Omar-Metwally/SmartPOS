
namespace SmartPOS.Domain.ValueObjects;

public class Address : ValueObject
{
    public int Id { get; private set; }
    public string Street { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;
    public string? Comment { get; private set; }

    private Address(string street, string city, string state, string country, string postalCode, string? comment)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        PostalCode = postalCode;
        Comment = comment;
    }

    private Address() { }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country} {PostalCode}, comment: {Comment}".TrimEnd();
    }

    public string ToSingleLineString()
    {
        return string.Join(", ", new[] { Street, City, State, Country, PostalCode, Comment }.Where(s => !string.IsNullOrWhiteSpace(s)));
    }

    public bool IsDomestic(string homeCountry)
    {
        return string.Equals(Country, homeCountry, StringComparison.OrdinalIgnoreCase);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return PostalCode;
    }
}

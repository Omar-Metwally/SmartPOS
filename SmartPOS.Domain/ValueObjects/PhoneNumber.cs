
namespace SmartPOS.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public string CountryCode { get; } = null!;
    public string Number { get; } = null!;
    public string? Comment { get; }

    private PhoneNumber() { }

    public PhoneNumber(string countryCode, string number, string? comment)
    {
        CountryCode = countryCode;
        Number = number;
        Comment = comment;
    }

    public string ToFormattedString()
    {
        if (!string.IsNullOrEmpty(CountryCode))
            return $"+{CountryCode} {FormatNationalNumber()}";
        return FormatNationalNumber();
    }

    private string FormatNationalNumber()
    {
        // This is a simple formatting. You might want to adjust based on specific country formats.
        if (Number.Length == 10)
            return $"({Number.Substring(0, 3)}) {Number.Substring(3, 3)}-{Number.Substring(6)}";
        return Number;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        yield return Number;
    }

    public override string ToString()
    {
        return ToFormattedString();
    }
}

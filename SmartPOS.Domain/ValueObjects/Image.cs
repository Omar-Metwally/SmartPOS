
namespace SmartPOS.Domain.ValueObjects;

public class Image : File
{
    private Image(string path, string fileName, string contentType)
    : base(path, fileName, contentType)
    {

    }

    private Image() { }

}

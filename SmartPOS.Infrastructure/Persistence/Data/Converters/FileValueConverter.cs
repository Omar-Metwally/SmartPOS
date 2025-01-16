using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using File = SmartPOS.Domain.ValueObjects.File;

namespace SmartPOS.Infrastructure.Persistence.Data.Converters;

public class FileValueConverter : ValueConverter<File, string>
{
    public FileValueConverter()
        : base(
            file => file.Path,
            path => File.Create(path))
    {
    }
}
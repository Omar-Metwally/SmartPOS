namespace SmartPOS.Domain.Entities.Products;

public class ProductUnit
{
    public int ProductInstanceId { get; private set; }
    public int UnitOfMeasureID { get; private set; }
    public UnitOfMeasure UnitOfMeasure { get; private set; } = null!;
}

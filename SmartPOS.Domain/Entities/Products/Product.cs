
namespace SmartPOS.Domain.Entities.Products;

public class Product : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public string ModelNumber { get; private set; } = null!;
    public int? ShelfLifeInDays { get; private set; }
    public int? WarrantyInDays { get; private set; }
    public bool DoesExpire => ShelfLifeInDays.HasValue;
    public bool IsWarranted => WarrantyInDays.HasValue;
    public bool AreItemsTracked => DoesExpire || IsWarranted;
    public int ManufacturerId { get; private set; }
    public int CategoryId { get; private set; }
    public virtual Manufacturer Manufacturer { get; private set; } = null!;
    public virtual Category Category { get; private set; } = null!;
    //public HashSet<ProductUnit> Units { get; private set; } = [];
    public HashSet<ProductInstance> Instances { get; private set; } = [];
}

namespace SmartPOS.Domain.Entities.Products;

public class Category : Entity, IAggregateRoot
{
    public int? ParentCategoryId { get; private set; }
    public string Name { get; private set; } = null!;
    public bool IsLeaf { get; private set; }
    public int ProductCount { get; private set; }
    public HashSet<Category> InverseParentCategory { get; private set; } = [];
    public virtual Category? ParentCategory { get; private set; }
}

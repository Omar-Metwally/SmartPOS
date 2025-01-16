namespace SmartPOS.Domain.Entities.Products;

public class ProductInstanceAttributeValue
{
    public int ProductInstanceId { get; internal set; }
    public int AttributeId { get; internal set; }
    public int AttributeValueId { get; internal set; }
    public virtual Attribute Attribute { get; internal set; } = null!;

    internal ProductInstanceAttributeValue(int productInstanceId, int attributeId, int attributeValueId)
    {
        ProductInstanceId = productInstanceId;
        AttributeId = attributeId;
        AttributeValueId = attributeValueId;
    }

    internal ProductInstanceAttributeValue(int attributeId, int attributeValueId)
    {
        AttributeId = attributeId;
        AttributeValueId = attributeValueId;
    }
}

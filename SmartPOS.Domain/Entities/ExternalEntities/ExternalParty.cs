using SmartPOS.Common.Enums;

namespace SmartPOS.Domain.Entities.ExternalEntities;

public abstract class ExternalParty : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public ExternalPartyType Type { get; private set; }
}

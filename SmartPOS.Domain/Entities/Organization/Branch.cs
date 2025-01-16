using SmartPOS.Common.Results;
using SmartPOS.Domain.Entities.Users;
using SmartPOS.Domain.ValueObjects;

namespace SmartPOS.Domain.Entities.Organization;

public class Branch : Entity, IAggregateRoot
{
    public string Name { get; private set; } = null!;
    public Address Address { get; private set; } = null!;
    public int? ManagerId { get; private set; }
    public virtual Employee? Manager { get; private set; }
    public HashSet<Employee> Employees { get; private set; } = [];

    private Branch(string name)
    {
        Name = name;
    }

    public static IResult<Branch> Create(string name)
    {
        return new Result<Branch>(new Branch(name));
    }
}
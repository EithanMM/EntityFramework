namespace Store.Data.Entities;

public class BaseEntity : Entity, IIdentity
{
    public int Identity { get; init; }
}

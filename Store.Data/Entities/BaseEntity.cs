namespace Store.Data.Entities;

public class BaseEntity : Entity, IHasIdentity
{
    public int Identity { get; init; }
}

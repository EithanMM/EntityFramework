namespace Store.Data.Entities;

public abstract class Entity : IHasId
{
    public string? Id { get; set; }
}

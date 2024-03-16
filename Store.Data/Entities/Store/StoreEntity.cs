namespace Store.Data.Entities.Store;

public class StoreEntity : Entity, IHasIdentity
{
    public int Identity { get; init; }
    public string? StoreId { get; set; }
    public string StoreName { get; set; } = string.Empty;
}

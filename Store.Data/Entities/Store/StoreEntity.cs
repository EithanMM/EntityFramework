namespace Store.Data.Entities.Store;

public class StoreEntity : Entity
{
    public string? StoreId { get; set; }
    public string StoreName { get; set; } = string.Empty;
}

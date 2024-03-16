using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities.Store;
using Store.Data.Extensions;

namespace Store.Data.EntityConfgurations;

internal sealed class StoreEntityConfiguration : IEntityTypeConfiguration<StoreEntity>
{
    public void Configure(EntityTypeBuilder<StoreEntity> builder)
    {
        builder.ToTable("Stores");

        builder
            .HasId()
            .HasSqlServerIdentity();

        builder
            .Property(x => x.StoreId)
            .IsRequired();

        builder.Property(x => x.StoreName)
            .HasMaxLength(256)
            .IsRequired();

        builder.HasData(new StoreEntity() { Id = "a1e1e197-6306-4426-b0a8-cc09df953e32", StoreId = "3602aee8-d325-4ca6-8390-395302b09a0f", StoreName = "StoreA" });
        builder.HasData(new StoreEntity() { Id = "513f3677-0f9c-44a5-a9db-0439e74c356e", StoreId = "add1be20-51a3-4a73-bc7b-be9509795ec0", StoreName = "StoreB" });
        builder.HasData(new StoreEntity() { Id = "a519ad44-cc1b-4ee6-acda-3509b7786584", StoreId = "0d3f7b07-d26e-431f-b92c-7e1eeec96900", StoreName = "StoreC" });
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entities;
using Store.Data.ValueGenerators;

namespace Store.Data.Extensions;

public static class EntityTypeBuilderExtensions
{
    // Generates an automatic ID for the record
    public static EntityTypeBuilder<TEntity> HasId<TEntity>(
        this EntityTypeBuilder<TEntity> builder,
        bool isPrimarykey = true) where TEntity : class, IHasId
    {
        if (isPrimarykey)
        {
            builder.HasKey(nameof(IHasId.Id))
                .IsClustered(false);
        }
        else
        {
            builder.HasIndex(nameof(IHasId.Id))
                .IsClustered(false);
        }

        builder.Property(nameof(IHasId.Id))
            .HasMaxLength(128)
            .HasValueGenerator<IdGenerator>();

        return builder;
    }

    //  Generates auto-increment value for identity field
    public static EntityTypeBuilder<TEntity> HasSqlServerIdentity<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : class, IHasIdentity
    {
        builder.HasIndex(nameof(IHasIdentity.Identity))
            .IsClustered();

        builder.Property(nameof(IHasIdentity.Identity))
            .ValueGeneratedOnAdd()
            .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        return builder;
    }
}

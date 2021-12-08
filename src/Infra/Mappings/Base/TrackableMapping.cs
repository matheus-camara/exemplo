using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infra.Mappings.Base;

internal abstract class TrackableMapping<T> : IEntityTypeConfiguration<T> where T : Trackable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(typeof(T).Name);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasValueGenerator<IdentityGenerator>();
    }
}

internal class IdentityGenerator : ValueGenerator<Guid>
{
    public override bool GeneratesTemporaryValues => false;

    public override Guid Next(EntityEntry entry)
    {
        return Guid.NewGuid();
    }
}
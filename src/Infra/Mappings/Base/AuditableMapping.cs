using Core.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infra.Mappings.Base;

internal abstract class AuditableMapping<T> : TrackableMapping<T> where T : Auditable
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Created).HasValueGenerator<DateGenerator>();
        builder.Property(x => x.CreatedBy);
        builder.Property(x => x.Modified).HasValueGenerator<DateGenerator>();
        builder.Property(x => x.ModifiedBy);
    }
}

internal class DateGenerator : ValueGenerator<DateTime?>
{
    public override bool GeneratesTemporaryValues => false;

    public override DateTime? Next(EntityEntry entry)
    {
        return DateTime.UtcNow;
    }
}

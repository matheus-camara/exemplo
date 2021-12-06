using Domain.Entities.Pros;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infra.Mappings
{
    internal class ReferralCodeMapping : IEntityTypeConfiguration<ReferralCodeEntity>
    {
        public void Configure(EntityTypeBuilder<ReferralCodeEntity> builder)
        {
            builder.ToTable(nameof(ReferralCode));

            builder.Property(x => x.Code).HasConversion(x => x.Value, x => new ReferralCode(x)).IsRequired().HasMaxLength(128);
        }
    }
}

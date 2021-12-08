using Domain.Entities.Pros;
using Infra.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

internal class ProMapping : AuditableMapping<Pro>
{
    public override void Configure(EntityTypeBuilder<Pro> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Age).IsRequired();
        builder.Property(x => x.EducationLevel).IsRequired();
        builder.Property(x => x.WritingScore).IsRequired().HasConversion(x => x.Value, x => new WritingScore(x));
        builder.Property(x => x.Score).IsRequired();
        builder.Property(x => x.ReferralCode);

        builder.OwnsOne(x => x.PastExperiences);
        builder.OwnsOne(x => x.InternetTest);
    }
}
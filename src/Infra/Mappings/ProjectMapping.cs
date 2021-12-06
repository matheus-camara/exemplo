using Domain.Entities.Projects;
using Infra.Mappings.Base;
using Infra.Seeds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings;

internal class ProjectMapping : AuditableMapping<Project>
{
    public override void Configure(EntityTypeBuilder<Project> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        builder.Property(x => x.MinimumScore).IsRequired();
    }
}

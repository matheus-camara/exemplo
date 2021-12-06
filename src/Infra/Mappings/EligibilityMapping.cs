using Domain.Entities.Eligibilities;
using Domain.Entities.Projects;
using Infra.Mappings.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    internal class EligibilityMapping : TrackableMapping<Eligibility>
    {
        public override void Configure(EntityTypeBuilder<Eligibility> builder)
        {
            const string FOREIGN_KEY_NAME = "ProId";

            base.Configure(builder);
            builder.Property<Guid>(FOREIGN_KEY_NAME);
            builder.HasOne(x => x.Pro).WithMany().HasForeignKey(FOREIGN_KEY_NAME).IsRequired();

            builder.HasMany(x => x.EligibleProjects).WithMany("Elegible").UsingEntity("ElegibleProjects");
            builder.HasMany(x => x.IneligibleProjects).WithMany("Inelegible").UsingEntity("InelegibleProjects");
            builder.HasOne(x => x.SelectedProject).WithMany();

            builder.Ignore(x => x.AvailableProjects);
            builder.Ignore(x => x.Rules);
        }
    }
}

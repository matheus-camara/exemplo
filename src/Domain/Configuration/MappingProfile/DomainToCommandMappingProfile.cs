using AutoMapper;
using Domain.Commands.CalculateEligibility.Results;
using Domain.Entities.Eligibilities;
using Domain.Entities.Projects;

namespace Domain.Configuration.MappingProfile
{
    public class DomainToCommandMappingProfile : Profile
    {
        public DomainToCommandMappingProfile()
        {
            CreateMap<ICollection<Project>, ICollection<string>>().ConvertUsing(x => x.Select(p => p.Name).ToList());
            CreateMap<Project?, string?>().ConvertUsing(x => x != null ? x.Name : null);

            CreateMap<Eligibility, CalculateEligibilityForProCommandResult>()
                .ForMember(x => x.Score, x => x.MapFrom(v => v.Pro.Score))
                .ForMember(x => x.SelectedProject, x => x.MapFrom(v => v.SelectedProject == null ? null : v.SelectedProject.Name));
        }
    }
}

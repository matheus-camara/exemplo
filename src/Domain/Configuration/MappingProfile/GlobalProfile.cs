using AutoMapper;

namespace Domain.Configuration.MappingProfile;

public class GlobalProfile : Profile
{
    public GlobalProfile()
    {
        SourceMemberNamingConvention = new PascalCaseNamingConvention();
        DestinationMemberNamingConvention = new PascalCaseNamingConvention();
        IgnoreNullValues();
    }

    private void IgnoreNullValues()
    {
        ForAllMaps((type, cfg) =>
            cfg.ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => src != null && srcMember != null)));
    }
}
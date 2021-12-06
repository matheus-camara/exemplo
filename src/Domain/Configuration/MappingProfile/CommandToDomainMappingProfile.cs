﻿using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using Domain.Commands.CalculateEligibility;
using Domain.Entities.Pros;
using System;

namespace Domain.Configuration.MappingProfile
{
    public class CommandToDomainMappingProfile : Profile
    {
        public CommandToDomainMappingProfile()
        {
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            CreateMap<InternetTestCommand, InternetTest>();
            CreateMap<PastExperiencesCommand, PastExperiences>();
            CreateMap<string, EducationLevel>().ConvertUsing(x => x.GetEducationLevel());
            CreateMap<CalculateEligibilityForProCommand, Pro>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Score, opt => opt.Ignore())
                .ForMember(x => x.CreatedBy, opt => opt.Ignore())
                .ForMember(x => x.Created, opt => opt.Ignore())
                .ForMember(x => x.ModifiedBy, opt => opt.Ignore())
                .ForMember(x => x.HasMinimunRequirementsForEligibility, opt => opt.Ignore())
                .ForMember(x => x.Modified, opt => opt.Ignore());
        }
    }
}

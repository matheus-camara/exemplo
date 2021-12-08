using AutoMapper;
using Domain.Commands.CalculateEligibility;
using Domain.Commands.CalculateEligibility.Results;
using Domain.Entities.Eligibilities;
using Domain.Entities.Projects;
using Domain.Entities.Pros;
using Domain.Entities.Rules.Pros;
using Domain.Repositories.Eligibilities;
using MediatR;

namespace Domain.Handlers.CalculateEligibility;

public class CalculateEligibilityCommandHandler : IRequestHandler<CalculateEligibilityForProCommand,
    CalculateEligibilityForProCommandResult>
{
    private readonly IEligibilityRepository _eligibilityRepository;
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IReferralCodeRepository _referralCodeRepository;

    public CalculateEligibilityCommandHandler(IProjectRepository projectRepository,
        IReferralCodeRepository referralCodeRepository, IEligibilityRepository eligibilityRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _referralCodeRepository = referralCodeRepository;
        _eligibilityRepository = eligibilityRepository;
        _mapper = mapper;
    }

    public async Task<CalculateEligibilityForProCommandResult> Handle(CalculateEligibilityForProCommand request,
        CancellationToken cancellationToken)
    {
        var pro = _mapper.Map<Pro>(request);
        var projects = await _projectRepository.GetCriticalProjectsOrderedByMinimumScore();

        var elibility = new Eligibility(pro, projects)
            .WithRule(new EducationLevelRule())
            .WithRule(new HasReferralCodeRule(_referralCodeRepository))
            .WithRule(new InternetTestRule())
            .WithRule(new IsUnderAgeRule())
            .WithRule(new PastExperiencesRule())
            .WithRule(new WritingScoreRule());

        await elibility.RunAnalysis();

        _eligibilityRepository.AddOrUpdate(elibility);

        return _mapper.Map<CalculateEligibilityForProCommandResult>(elibility);
    }
}
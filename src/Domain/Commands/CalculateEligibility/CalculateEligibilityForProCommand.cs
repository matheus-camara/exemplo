using Domain.Commands.CalculateEligibility.Results;
using MediatR;

namespace Domain.Commands.CalculateEligibility
{
    public record CalculateEligibilityForProCommand(
        ushort Age,
        string EducationLevel,
        double WritingScore,
        string ReferralCode,
        PastExperiencesCommand PastExperiences,
        InternetTestCommand InternetTest) : IRequest<CalculateEligibilityForProCommandResult>;
}
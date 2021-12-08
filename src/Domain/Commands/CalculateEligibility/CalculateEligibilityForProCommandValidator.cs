using Domain.Validators;
using FluentValidation;

namespace Domain.Commands.CalculateEligibility;

public class CalculateEligibilityForProCommandValidator : AbstractValidator<CalculateEligibilityForProCommand>
{
    public CalculateEligibilityForProCommandValidator()
    {
        RuleFor(x => x.Age)
            .NotEmpty();

        RuleFor(x => x.EducationLevel)
            .IsValidEducationLevel();

        RuleFor(x => x.ReferralCode)
            .NotEmpty();

        RuleFor(x => x.WritingScore)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(1);

        RuleFor(x => x.InternetTest)
            .NotEmpty()
            .SetValidator(new InternetTestCommandValidator());

        RuleFor(x => x.PastExperiences)
            .NotNull()
            .SetValidator(new PastExperiencesCommandValidator());
    }
}
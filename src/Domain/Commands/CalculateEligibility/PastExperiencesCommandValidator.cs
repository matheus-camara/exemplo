using FluentValidation;

namespace Domain.Commands.CalculateEligibility;

public class PastExperiencesCommandValidator : AbstractValidator<PastExperiencesCommand?>
{
    public PastExperiencesCommandValidator()
    {
        RuleFor(x => x.Sales)
            .NotNull();

        RuleFor(x => x.Support)
            .NotNull();
    }
}
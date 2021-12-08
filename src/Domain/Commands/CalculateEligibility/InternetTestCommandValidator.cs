using FluentValidation;

namespace Domain.Commands.CalculateEligibility;

public class InternetTestCommandValidator : AbstractValidator<InternetTestCommand>
{
    public InternetTestCommandValidator()
    {
        RuleFor(x => x.DownloadSpeed)
            .NotEmpty();

        RuleFor(x => x.UploadSpeed)
            .NotEmpty();
    }
}
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CalculateEligibility
{
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
}

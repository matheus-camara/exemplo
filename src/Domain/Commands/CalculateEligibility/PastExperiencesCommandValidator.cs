using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CalculateEligibility
{
    public class PastExperiencesCommandValidator : AbstractValidator<PastExperiencesCommand>
    {
        public PastExperiencesCommandValidator()
        {
            RuleFor(x => x.Sales)
                .NotNull();

            RuleFor(x => x.Support)
                .NotNull();
        }
    }
}

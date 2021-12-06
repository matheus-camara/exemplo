using Domain.Entities.Pros;
using Domain.Validators;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.CalculateEligibility
{
    public class CalculateEligibilityForProCommandValidator : AbstractValidator<CalculateEligibilityForProCommand>
    {
        public CalculateEligibilityForProCommandValidator()
        {
            RuleFor(x => x.Age).NotEmpty();

            RuleFor(x => x.EducationLevel).IsValidEducationLevel();

            RuleFor(x => x.ReferralCode).NotEmpty();
            RuleFor(x => x.WritingScore).NotEmpty();

            RuleFor(x => x.InternetTest)
                .NotEmpty()
                .SetValidator(new InternetTestCommandValidator());

            RuleFor(x => x.PastExperiences)
                .NotNull()
                .SetValidator(new PastExperiencesCommandValidator());
        }
    }
}

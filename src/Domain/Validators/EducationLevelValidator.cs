using Core.Policies;
using Domain.Entities.Pros;
using FluentValidation;

namespace Domain.Validators;

public static class EducationLevelValidator
{
    private const string Placeholder = "{levels}";
    private const string MessageTemplate = "{PropertyName} must be one of '" + Placeholder + "'";

    private static readonly string EducationLevelOptions = string.Join(", ",
        Enum.GetNames(typeof(EducationLevel)).Select(x => new SnakeCaseNamingPolicy().ConvertName(x)));

    private static readonly string Message = MessageTemplate.Replace(Placeholder, EducationLevelOptions);

    public static IRuleBuilderOptions<T, string> IsValidEducationLevel<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(x => x.GetEducationLevel() is not 0).WithMessage(Message);
    }
}
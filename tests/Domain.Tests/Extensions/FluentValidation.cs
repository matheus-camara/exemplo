using FluentValidation.Results;

namespace FluentAssertions;

public static class FluentValidation
{
    public static void ShouldHaveValidationError(this ValidationResult that)
    {
        that.IsValid.Should().BeFalse();
    }

    public static void ShouldNotHaveValidationError(this ValidationResult that)
    {
        that.IsValid.Should().BeTrue();
    }
}
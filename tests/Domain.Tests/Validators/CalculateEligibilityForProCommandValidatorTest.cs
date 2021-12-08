namespace Domain.Tests.Validators;

public class CalculateEligibilityForProCommandValidatorTest
{
    private readonly CalculateEligibilityForProCommandValidator _validator;

    public CalculateEligibilityForProCommandValidatorTest()
    {
        _validator = new CalculateEligibilityForProCommandValidator();
    }

    [Fact]
    public void ShouldPassValidationWithValidData()
    {
        var command = DataGenerator.CalculateEligibilityForProCommand.Generate();
        var result = _validator.Validate(command);
        result.Errors.Should().BeEmpty();
        result.ShouldNotHaveValidationError();
    }
}
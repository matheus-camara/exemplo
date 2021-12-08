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
        _validator.Validate(command).ShouldNotHaveValidationError();
    }
}
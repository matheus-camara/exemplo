namespace Domain.Tests.Validators;

public class PastExperiencesCommandValidatorTests
{
    private readonly PastExperiencesCommandValidator _validator;

    public PastExperiencesCommandValidatorTests()
    {
        _validator = new PastExperiencesCommandValidator();
    }

    [Fact]
    public void ShouldPassValidationWithValidData()
    {
        var command = DataGenerator.PastExperiencesCommand.Generate();
        _validator.Validate(command).ShouldNotHaveValidationError();
    }
}
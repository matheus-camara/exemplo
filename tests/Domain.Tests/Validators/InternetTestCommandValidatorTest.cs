namespace Domain.Tests.Validators;

public class InternetTestCommandValidatorTest
{
    private readonly InternetTestCommandValidator _validator;

    public InternetTestCommandValidatorTest()
    {
        _validator = new InternetTestCommandValidator();
    }

    [Fact]
    public void ShouldPassValidationWithValidData()
    {
        var command = DataGenerator.InternetTestCommand.Generate();
        _validator.Validate(command).ShouldNotHaveValidationError();
    }
}
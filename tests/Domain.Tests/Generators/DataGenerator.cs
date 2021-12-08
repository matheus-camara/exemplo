using Bogus;

namespace Domain.Tests.Generators;

public static class DataGenerator
{
    private static string[] EducationLevels => new[]
    {
        EducationLevel.BachelorsOrHigher.GetStringRepresentation(),
        EducationLevel.HighSchool.GetStringRepresentation(),
        EducationLevel.NoEducation.GetStringRepresentation()
    };

    public static Faker<InternetTestCommand> InternetTestCommand
        => new Faker<InternetTestCommand>()
            .CustomInstantiator(x => new InternetTestCommand(x.Random.Double(), x.Random.Double()));

    public static Faker<PastExperiencesCommand> PastExperiencesCommand
        => new Faker<PastExperiencesCommand>()
            .CustomInstantiator(x => new PastExperiencesCommand(x.Random.Bool(), x.Random.Bool()));

    public static Faker<CalculateEligibilityForProCommand> CalculateEligibilityForProCommand
        => new Faker<CalculateEligibilityForProCommand>()
            .CustomInstantiator(x => new CalculateEligibilityForProCommand(
                x.Random.UShort(),
                x.PickRandom(EducationLevels),
                x.Random.Byte(0, 1),
                x.Random.String(),
                PastExperiencesCommand.Generate(),
                InternetTestCommand.Generate()));
}
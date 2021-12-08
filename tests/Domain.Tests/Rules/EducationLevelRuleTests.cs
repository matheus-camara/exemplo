namespace Domain.Tests.Rules;

public class EducationLevelRuleTests : BaseTest
{
    [Fact]
    public void ShouldNotIncrementScoreForNoEducationPro()
    {
        var noEducationPro = CreatePro(default, EducationLevel.NoEducation);

        EducationLevelRule.Run(noEducationPro);

        noEducationPro.Score.Should().Be(0);
    }

    [Fact]
    public async void ShouldIncrementScoreForHighSchoolEducationPro()
    {
        var noEducationPro = CreatePro(default);
        await EducationLevelRule.Run(noEducationPro);
        noEducationPro.Score.Should().Be(1);
    }

    [Fact]
    public async void ShouldIncrementScoreForBacherlorsOrHigherEducationPro()
    {
        var noEducationPro = CreatePro(default, EducationLevel.BachelorsOrHigher);

        await EducationLevelRule.Run(noEducationPro);
        noEducationPro.Score.Should().Be(2);
    }
}
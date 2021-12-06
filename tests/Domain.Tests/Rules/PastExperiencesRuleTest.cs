using FluentAssertions;
using Xunit;

namespace Domain.Tests.Rules;
public class PastExperiencesRuleTest : BaseTest
{
    [Fact]
    public async void ShouldIncreaseScoreForProWithPastExperienceOnSales()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(true));

        await PastExperiencesRule.Run(pro);

        pro.Score.Should().Be(5);
    }

    [Fact]
    public async void ShouldIncreaseScoreForProWithPastExperienceOnSupport()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(support: true));

        await PastExperiencesRule.Run(pro);

        pro.Score.Should().Be(3);
    }

    [Fact]
    public async void ShouldNotIncreaseScoreForProWithoutPastExperience()
    {
        var pro = CreatePro(experiences: CreatePastExperiences());

        await PastExperiencesRule.Run(pro);

        pro.Score.Should().Be(0);
    }

    [Fact]
    public async void ShouldIncreaseScoreForProWithPastExperienceOnBothSupportAndSales()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(true, true));

        await PastExperiencesRule.Run(pro);

        pro.Score.Should().Be(8);
    }
}

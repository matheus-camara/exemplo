using Domain.Entities.Pros;
using Domain.Entities.Rules.Pros;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Rules;
public class WritingScoreRuleTest : BaseTest
{
    [Fact]
    public async void ShouldDecreaseScoreWhenProHasLowWritingScore()
    {
        var pro = CreatePro(writingScore: new WritingScore(0.2));

        await WritingScoreRule.Run(pro);

        pro.Score.Should().Be(-1);
    }

    [Fact]
    public async void ShouldIncreaseScoreWhenProHasRegularWritingScore()
    {
        var pro = CreatePro(writingScore: new WritingScore(0.3));

        await WritingScoreRule.Run(pro);

        pro.Score.Should().Be(1);
    }

    [Fact]
    public async void ShouldDecreaseScoreWhenProHasHighWritingScore()
    {
        var pro = CreatePro(writingScore: new WritingScore(0.7));

        await WritingScoreRule.Run(pro);

        pro.Score.Should().Be(2);
    }
}

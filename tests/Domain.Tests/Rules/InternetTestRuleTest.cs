using Domain.Entities.Rules.Pros;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Rules;
public class InternetTestRuleTest : BaseTest
{
    [Fact]
    public async void ShouldIncreaseScoreForHighDownloadSpeed()
    {
        var pro = CreatePro(internetTest: CreateInternetTest(55, 10));

        await InternetTestRule.Run(pro);

        pro.Score.Should().Be(1);
    }

    [Fact]
    public async void ShouldIncreaseScoreForLowDownloadSpeed()
    {
        var pro = CreatePro(internetTest: CreateInternetTest(4, 10));

        await InternetTestRule.Run(pro);

        pro.Score.Should().Be(-1);

    }

    [Fact]
    public async void ShouldIncreaseScoreForHighUploadSpeed()
    {
        var pro = CreatePro(internetTest: CreateInternetTest(10, 55));

        await InternetTestRule.Run(pro);
        pro.Score.Should().Be(1);
    }

    [Fact]
    public async void ShouldIncreaseScoreForLowUploadSpeed()
    {
        var pro = CreatePro(internetTest: CreateInternetTest(10, 4));

        await InternetTestRule.Run(pro);

        pro.Score.Should().Be(-1);
    }
}

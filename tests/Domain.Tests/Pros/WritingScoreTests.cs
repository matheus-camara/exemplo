namespace Domain.Tests.Pros;

public class WritingScoreTests
{
    [Fact]
    public void ShouldCreateWritingScoreWithValidValue()
    {
        const double value = 0.5;

        var writingScore = new WritingScore(value);

        writingScore.Value.Should().Be(value);
    }

    [Fact]
    public void ShouldCreateValidWritingScoreWithInvalidHigherValue()
    {
        const double value = 1.5;
        const double max_valid = 1;

        var writingScore = new WritingScore(value);
        writingScore.Value.Should().Be(max_valid);
    }

    [Fact]
    public void ShouldCreateValidWritingScoreWithInvalidLowerValue()
    {
        const double value = -1;
        const double min_valid = 0;

        var writingScore = new WritingScore(value);
        writingScore.Value.Should().Be(min_valid);
    }
}
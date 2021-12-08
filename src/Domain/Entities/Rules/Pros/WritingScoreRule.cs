using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros;

public class WritingScoreRule : IRule<Pro>
{
    private const double LOW_END = 0.3;
    private const double HIGH_END = 0.7;

    public Task Run(Pro target)
    {
        var score = target.WritingScore;
        if (score < LOW_END)
            target.DecreaseScore(1);

        else if (score >= LOW_END && score < HIGH_END)
            target.IncreaseScore(1);

        else if (score >= HIGH_END)
            target.IncreaseScore(2);

        return Task.CompletedTask;
    }
}
using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros;

public class EducationLevelRule : IRule<Pro>
{
    public Task Run(Pro target)
    {
        var score = target.EducationLevel switch
        {
            EducationLevel.HighSchool => 1,
            EducationLevel.BachelorsOrHigher => 2,
            _ => 0
        };

        target.IncreaseScore(score);
        return Task.CompletedTask;
    }
}
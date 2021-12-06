using System.Threading.Tasks;
using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros
{
    public class PastExperiencesRule : IRule<Pro>
    {
        public Task Run(Pro target)
        {
            if (target.PastExperiences.Sales)
            {
                target.IncreaseScore(5);
            }
            if (target.PastExperiences.Support)
            {
                target.IncreaseScore(3);
            }

            return Task.CompletedTask;
        }
    }
}
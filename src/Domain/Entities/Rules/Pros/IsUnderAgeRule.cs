using System.Threading.Tasks;
using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros
{
    public class IsUnderAgeRule : IRule<Pro>
    {
        public Task Run(Pro target)
        {
            if (target.IsUnderAge)
            {
                target.Invalidate();
            }

            return Task.CompletedTask;
        }
    }
}
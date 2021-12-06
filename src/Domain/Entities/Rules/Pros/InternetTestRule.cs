using System.Threading.Tasks;
using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros
{
    public class InternetTestRule : IRule<Pro>
    {
        public Task Run(Pro target)
        {
            SpeedRule(target, target.InternetTest.DownloadSpeed);
            SpeedRule(target, target.InternetTest.UploadSpeed);
            return Task.CompletedTask;
        }

        private void SpeedRule(Pro target, double speed)
        {
            if (speed > 50)
            {
                target.IncreaseScore(1);
                return;
            }

            if (speed < 5)
            {
                target.DecreaseScore(1);
            }
        }
    }
}
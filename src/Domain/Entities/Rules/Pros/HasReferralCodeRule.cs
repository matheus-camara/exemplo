using System.Threading.Tasks;
using Domain.Entities.Pros;

namespace Domain.Entities.Rules.Pros
{
    public class HasReferralCodeRule : IRule<Pro>
    {
        private readonly IReferralCodeRepository _repository;

        public HasReferralCodeRule(IReferralCodeRepository repository)
        {
            _repository = repository;
        }

        public async Task Run(Pro target)
        {
            if (!string.IsNullOrEmpty(target.ReferralCode) && await _repository.ReferralCodeExists(target.ReferralCode))
            {
                target.IncreaseScore(1);
            }
        }
    }
}
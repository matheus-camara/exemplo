using Domain.Entities.Pros;
using Infra.Contexts;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    internal class ReferralCodeRepository : IReferralCodeRepository
    {
        private Context Context { get; init; }

        public ReferralCodeRepository(Context context)
        {
            Context = context;
        }

        public async Task<bool> ReferralCodeExists(ReferralCode code) => await Context.Set<ReferralCodeEntity>().AnyAsync(x => x.Code == code);
    }
}
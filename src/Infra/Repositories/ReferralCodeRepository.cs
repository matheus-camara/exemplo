using Domain.Entities.Pros;
using Infra.Contexts;
using Infra.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories;

internal class ReferralCodeRepository : IReferralCodeRepository
{
    public ReferralCodeRepository(Context context)
    {
        Context = context;
    }

    private Context Context { get; }

    public async Task<bool> ReferralCodeExists(ReferralCode code)
    {
        return await Context.Set<ReferralCodeEntity>().AnyAsync(x => x.Code == code);
    }
}
using Domain.Entities.Eligibilities;
using Domain.Repositories.Eligibilities;
using Infra.Contexts;

namespace Infra.Repositories;

internal class EligiblityRepository : Repository<Eligibility>, IEligibilityRepository
{
    public EligiblityRepository(Context context) : base(context)
    {
    }
}


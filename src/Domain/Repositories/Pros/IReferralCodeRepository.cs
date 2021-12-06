using Domain.Repositories;

namespace Domain.Entities.Pros;

public interface IReferralCodeRepository
{
    Task<bool> ReferralCodeExists(ReferralCode code);
}
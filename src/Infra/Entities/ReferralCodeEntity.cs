using Core.Entities;
using Domain.Entities.Pros;

namespace Infra.Entities;

internal class ReferralCodeEntity : Trackable
{
    public ReferralCode Code { get; set; }
}
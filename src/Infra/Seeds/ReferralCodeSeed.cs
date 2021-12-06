using Infra.Contexts;
using Infra.Entities;

namespace Infra.Seeds
{
    internal static class ReferralCodeSeed
    {
        private static ReferralCodeEntity[] Data => new[]
        {
            new ReferralCodeEntity
            {
                Id = Guid.NewGuid(),
                Code = "token1234"
            },
        };

        internal static void AddReferralCodeSeed(this Context that) => that.AddRange(Data);
    }
}
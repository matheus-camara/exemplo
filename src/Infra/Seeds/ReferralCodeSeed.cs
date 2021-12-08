using Infra.Contexts;
using Infra.Entities;

namespace Infra.Seeds;

internal static class ReferralCodeSeed
{
    private static ReferralCodeEntity[] Data => new[]
    {
        new ReferralCodeEntity
        {
            Id = Guid.Parse("cc7d3952-da72-4536-9542-e79d803954e7"),
            Code = "token1234"
        }
    };

    internal static void AddReferralCodeSeed(this Context that)
    {
        foreach (var code in Data)
            if (!that.Set<ReferralCodeEntity>().Any(x => x.Id == code.Id))
                that.Add(code);
    }
}
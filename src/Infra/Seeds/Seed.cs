using Infra.Contexts;

namespace Infra.Seeds;

public static class Seed
{
    public static void ApplySeeds(this Context context)
    {
        context.AddProjectSeed();
        context.AddReferralCodeSeed();
        context.SaveChangesAsync().Wait();
    }
}
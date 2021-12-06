using Domain.Entities.Projects;
using Infra.Contexts;

namespace Infra.Seeds
{
    internal static class ProjectSeed
    {
        private static Project[] Data => new Project[]
        {
            new (Guid.NewGuid(), "Calculate the Dark Matter of the universe for Nasa", 10),
            new (Guid.NewGuid(), "Determine if the Schrodinger's cat is alive", 5),
            new (Guid.NewGuid(), "Attend to users support for a YXZ Company", 3),
            new (Guid.NewGuid(), "Collect specific people information from their social media for XPTO Company", 2),
        };

        internal static void AddProjectSeed(this Context that) => that.AddRange(Data);
    }
}
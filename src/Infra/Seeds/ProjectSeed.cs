using Domain.Entities.Projects;
using Infra.Contexts;

namespace Infra.Seeds
{
    internal static class ProjectSeed
    {
        private static Project[] Data => new Project[]
        {
            new (Guid.Parse("67630ab0-0f65-4757-884f-173b25f05633"), "Calculate the Dark Matter of the universe for Nasa", 10),
            new (Guid.Parse("72468cac-b39c-4d52-9e16-1a94dea20313"), "Determine if the Schrodinger's cat is alive", 5),
            new (Guid.Parse("46d14079-a639-4a07-a01e-10dbbaa064f0"), "Attend to users support for a YXZ Company", 3),
            new (Guid.Parse("ab5150ce-b235-4454-b2b3-50d9fa1b9d04"), "Collect specific people information from their social media for XPTO Company", 2),
        };

        internal static void AddProjectSeed(this Context that)
        {
            foreach (var project in Data)
            {
                if (!that.Set<Project>().Any(x => x.Id == project.Id)) that.Add(project);
            }
        }
    }
}
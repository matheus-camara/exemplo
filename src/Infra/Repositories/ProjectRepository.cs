using Domain.Entities.Projects;
using Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    internal class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(Context context) : base(context)
        {
        }
        public async Task<ICollection<Project>> GetCriticalProjectsOrderedByMinimumScore()
            => await DbSet.OrderByDescending(x => x.MinimumScore).ToListAsync();
    }
}
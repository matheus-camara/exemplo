using Domain.Repositories;

namespace Domain.Entities.Projects;

public interface IProjectRepository : IRepository<Project>
{
    Task<ICollection<Project>> GetCriticalProjectsOrderedByMinimumScore();
}
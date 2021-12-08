using Core.Entities;
using Domain.Entities.Eligibilities;
using Domain.Entities.Pros;

namespace Domain.Entities.Projects;

public class Project : Auditable
{
    public Project(string name, int minimumScore)
    {
        (Name, MinimumScore) = (name, minimumScore);
    }

    public Project(Guid id, string name, int minimumScore) : base(id)
    {
        (Name, MinimumScore) = (name, minimumScore);
    }

    public string Name { get; init; }
    public int MinimumScore { get; init; }
    private ICollection<Eligibility>? Elegible { get; init; }
    private ICollection<Eligibility>? Inelegible { get; init; }

    public bool IsProEligible(Pro pro)
    {
        return pro.Score >= MinimumScore;
    }
}
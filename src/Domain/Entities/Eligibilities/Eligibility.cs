using Core.Entities;
using Domain.Entities.Projects;
using Domain.Entities.Pros;
using Domain.Entities.Rules;

namespace Domain.Entities.Eligibilities;

public class Eligibility : Auditable
{
    public Pro Pro { get; init; }
    public Project? SelectedProject { get; private set; }
    public ICollection<Project> AvailableProjects { get; init; } = new List<Project>();
    public ICollection<Project> EligibleProjects { get; private set; } = new List<Project>();
    public ICollection<Project> IneligibleProjects { get; private set; } = new List<Project>();
    public ICollection<IRule<Pro>> Rules { get; private set; } = new List<IRule<Pro>>();

    public Eligibility(Pro pro, ICollection<Project> availableProjects)
    {
        Pro = pro;
        AvailableProjects = availableProjects;
    }

    private Eligibility()
    {
        Pro = default!;
    }

    public Eligibility WithRule(IRule<Pro> rule)
    {
        Rules.Add(rule);
        return this;
    }

    public async Task RunAnalysis()
    {
        await CalculateScore();

        foreach (var project in AvailableProjects.OrderByDescending(x => x.MinimumScore))
        {
            if (project.IsProEligible(Pro))
            {
                EligibleProjects.Add(project);
                SelectedProject ??= project;
            }
            else
            {
                IneligibleProjects.Add(project);
            }
        }
    }

    private Task CalculateScore()
        => Rules.Any() ? Task.WhenAll(Rules.Select(x => x.Run(Pro))) : Task.CompletedTask;
}

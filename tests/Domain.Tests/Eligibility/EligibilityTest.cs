using Domain.Entities.Eligibilities;
using Domain.Entities.Projects;
using FluentAssertions;
using Xunit;

namespace Domain.Tests.Eligibilities;
public class EligibilityTest : BaseTest
{
    [Fact]
    public async void ShouldCalculateScore()
    {
        var pro = CreatePro();
        var eligibility = new Eligibility(pro, Array.Empty<Project>())
                            .WithRule(EducationLevelRule)
                            .WithRule(WritingScoreRule);

        await eligibility.RunAnalysis();

        Assert.Equal(3, pro.Score);
    }

    [Fact]
    public async void ShouldNotSelectProjectIfProHasLowerScoreThanRequired()
    {
        var pro = CreatePro();
        var eligibility = new Eligibility(pro, new List<Project>() { new Project("not a valid project", 50) });

        await eligibility.RunAnalysis();

        Assert.Null(eligibility.SelectedProject);
    }

    [Fact]
    public async void ShouldAddToTheIneligibleProjectsIfProHasLowerScoreThanRequired()
    {
        var pro = CreatePro();
        var project = new Project("not a valid project", 50);

        var eligibility = new Eligibility(pro, new List<Project>() { project });

        await eligibility.RunAnalysis();

        Assert.Contains(project, eligibility.IneligibleProjects);
    }

    [Fact]
    public async void ShouldSelectProjectIfProHasRequiredScore()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(true, true));
        var project = new Project("not a valid project", 5);

        var eligibility = new Eligibility(pro, new List<Project>() { project })
                            .WithRule(WritingScoreRule)
                            .WithRule(PastExperiencesRule)
                            .WithRule(EducationLevelRule);

        await eligibility.RunAnalysis();

        Assert.Equal(project, eligibility.SelectedProject);
    }

    [Fact]
    public async void ShouldSelectProjectWithHigherScore()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(true, true));
        var projects = new List<Project>()
            {
                new Project("not a valid project", 2),
                new Project("not a valid project", 5),
                new Project("not a valid project", 3),
                new Project("not a valid project", 4),
            };

        var eligibility = new Eligibility(pro, projects)
                            .WithRule(WritingScoreRule)
                            .WithRule(PastExperiencesRule)
                            .WithRule(EducationLevelRule);

        await eligibility.RunAnalysis();

        eligibility.SelectedProject?.MinimumScore.Should().Be(5);
    }

    [Fact]
    public async void ShouldAddToEligibleProjectsIfProHasHigherScoreThanRequired()
    {
        var pro = CreatePro(experiences: CreatePastExperiences(true, true));
        var projects = new List<Project>()
            {
                new Project("not a valid project", 2),
                new Project("not a valid project", 5),
                new Project("not a valid project", 3),
                new Project("not a valid project", 4),
            };

        var eligibility = new Eligibility(pro, projects)
                            .WithRule(WritingScoreRule)
                            .WithRule(PastExperiencesRule)
                            .WithRule(EducationLevelRule);

        await eligibility.RunAnalysis();

        eligibility.EligibleProjects.Count.Should().Be(4);
    }
}

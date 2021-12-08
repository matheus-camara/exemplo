namespace Domain.Commands.CalculateEligibility.Results;

public record CalculateEligibilityForProCommandResult
{
    public int? Score { get; set; }
    public string? SelectedProject { get; set; }
    public ICollection<string>? EligibleProjects { get; set; }
    public ICollection<string>? IneligibleProjects { get; set; }
}
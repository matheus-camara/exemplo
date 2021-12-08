using Core.Entities;

namespace Domain.Entities.Pros;

public class Pro : Auditable
{
    private const int LEGAL_AGE = 18;

    public Pro(uint age, EducationLevel educationLevel, PastExperiences pastExperiences, InternetTest internetTest,
        WritingScore writingScore, string? referralCode)
    {
        Age = age;
        EducationLevel = educationLevel;
        PastExperiences = pastExperiences;
        InternetTest = internetTest;
        WritingScore = writingScore;
        ReferralCode = referralCode;
        HasMinimunRequirementsForEligibility = true;
    }

    private Pro(uint age, EducationLevel educationLevel, WritingScore writingScore, string? referralCode,
        bool hasMinimunRequirementsForEligibility, int score)
    {
        Age = age;
        EducationLevel = educationLevel;
        WritingScore = writingScore;
        ReferralCode = referralCode;
        HasMinimunRequirementsForEligibility = hasMinimunRequirementsForEligibility;
        Score = score;
        PastExperiences = default!;
        InternetTest = default!;
    }

    public uint Age { get; init; }
    public EducationLevel EducationLevel { get; init; }
    public PastExperiences PastExperiences { get; init; }
    public InternetTest InternetTest { get; init; }
    public WritingScore WritingScore { get; init; }
    public string? ReferralCode { get; init; }
    public bool HasMinimunRequirementsForEligibility { get; private set; }
    public int Score { get; private set; }
    public bool IsUnderAge => Age < LEGAL_AGE;

    public void IncreaseScore(int value)
    {
        Score += value;
    }

    public void DecreaseScore(int value)
    {
        Score -= value;
    }

    public void Invalidate()
    {
        HasMinimunRequirementsForEligibility = false;
    }
}
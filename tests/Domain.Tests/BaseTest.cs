using Domain.Entities.Pros;
using Domain.Entities.Rules.Pros;
using Moq;

namespace Domain.Tests;

public abstract class BaseTest
{
    protected readonly EducationLevelRule EducationLevelRule = new();
    protected readonly InternetTestRule InternetTestRule = new();
    protected readonly IsUnderAgeRule IsUnderAgeRule = new();
    protected readonly PastExperiencesRule PastExperiencesRule = new();
    protected readonly WritingScoreRule WritingScoreRule = new();
    protected readonly Mock<IReferralCodeRepository> _referralCodeRepository;
    protected BaseTest()
    {
        _referralCodeRepository = new();
    }

    public Pro CreatePro(
        ushort age = 25,
        EducationLevel education = EducationLevel.HighSchool,
        PastExperiences experiences = default!,
        InternetTest internetTest = default!,
        double writingScore = 1,
        string referralCode = "")
        => new Pro(age, education, experiences, internetTest, writingScore, referralCode);

    public PastExperiences CreatePastExperiences(bool sales = false, bool support = false)
        => new PastExperiences(sales, support);

    public InternetTest CreateInternetTest(double downloadSpeed = 55, double uploadSpeed = 55)
        => new InternetTest(downloadSpeed, uploadSpeed);
}

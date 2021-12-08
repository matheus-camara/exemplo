namespace Domain.Tests.Rules;

public class IsUnderAgeRuleTest : BaseTest
{
    [Fact]
    public async void ShouldInvalidateProWhenUnderAge()
    {
        var pro = CreatePro(15);

        await IsUnderAgeRule.Run(pro);

        pro.HasMinimunRequirementsForEligibility.Should().BeFalse();
    }

    [Fact]
    public async void ShouldNotInvalidateProWhenIsNotUnderAge()
    {
        var pro = CreatePro(18);

        await IsUnderAgeRule.Run(pro);

        pro.HasMinimunRequirementsForEligibility.Should().BeTrue();
    }
}
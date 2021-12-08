namespace Domain.Tests.Rules;

public class HasReferralCodeRuleTest : BaseTest
{
    [Fact]
    public async void ShouldNotIncrementScoreOfProWithoutReferralCode()
    {
        _referralCodeRepository
            .Setup(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()))
            .ReturnsAsync(false);

        var rule = new HasReferralCodeRule(_referralCodeRepository.Object);
        var noCodePro = CreatePro();

        await rule.Run(noCodePro);

        noCodePro.Score.Should().Be(0);
        _referralCodeRepository.Verify(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()), Times.Never);
    }

    [Fact]
    public async void ShouldIncrementScoreOfProWithValidReferralCode()
    {
        _referralCodeRepository
            .Setup(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()))
            .ReturnsAsync(true);

        var rule = new HasReferralCodeRule(_referralCodeRepository.Object);
        var noCodePro = CreatePro(referralCode: "token1234");

        await rule.Run(noCodePro);

        noCodePro.Score.Should().Be(1);
        _referralCodeRepository.Verify(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()), Times.Once);
    }

    [Fact]
    public async void ShouldIncrementScoreOfProWithInvalidReferralCode()
    {
        _referralCodeRepository
            .Setup(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()))
            .ReturnsAsync(false);

        var rule = new HasReferralCodeRule(_referralCodeRepository.Object);
        var noCodePro = CreatePro(referralCode: "token1234");

        await rule.Run(noCodePro);

        noCodePro.Score.Should().Be(0);
        _referralCodeRepository.Verify(x => x.ReferralCodeExists(It.IsAny<ReferralCode>()), Times.Once);
    }
}
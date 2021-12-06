namespace Domain.Entities.Pros;

public readonly record struct ReferralCode(string Value)
{
    public static implicit operator ReferralCode(string value)
        => new ReferralCode(value);

    public static implicit operator string(ReferralCode score)
        => score.Value;
}
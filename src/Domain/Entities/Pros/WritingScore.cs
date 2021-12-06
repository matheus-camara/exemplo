namespace Domain.Entities.Pros;

public record WritingScore
{
    private const byte MAX_VALUE = 1;
    private const byte MIN_VALUE = 0;

    public double Value { get; init; }

    public WritingScore(double value)
    {
        Value = value switch
        {
            > MAX_VALUE => MAX_VALUE,
            < MIN_VALUE => MIN_VALUE,
            _ => value
        };
    }

    public static implicit operator WritingScore(double value)
        => new WritingScore(value);

    public static implicit operator double(WritingScore score)
        => score.Value;
}

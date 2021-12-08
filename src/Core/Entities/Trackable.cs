namespace Core.Entities;

public abstract class Trackable
{
    protected Trackable()
    {
    }

    protected Trackable(Guid? id)
    {
        Id = id;
    }

    public Guid? Id { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is Trackable @base && Id == @base.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Trackable? one, object? other)
    {
        return one?.Equals(other) ?? false;
    }

    public static bool operator !=(Trackable? one, object? other)
    {
        return !(one == other);
    }
}
namespace Core.Entities;
public abstract class Trackable
{
    public Guid? Id { get; init; }

    public override bool Equals(object? obj) => obj is Trackable @base && Id == @base.Id;
    public override int GetHashCode() => HashCode.Combine(Id);
    public static bool operator ==(Trackable? one, object? other) => one?.Equals(other) ?? false;
    public static bool operator !=(Trackable? one, object? other) => !(one == other);

    protected Trackable() { }

    protected Trackable(Guid? id)
    {
        Id = id;
    }
}

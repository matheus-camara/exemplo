namespace Core.Entities;

public abstract class Auditable : Trackable
{
    public Guid? CreatedBy;
    public DateTime? Created;
    public Guid? ModifiedBy;
    public DateTime? Modified;
    protected Auditable() { }

    protected Auditable(Guid? id) : base(id)
    {
    }
}

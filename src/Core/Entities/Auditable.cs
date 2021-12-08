namespace Core.Entities;

public abstract class Auditable : Trackable
{
    public DateTime? Created;
    public Guid? CreatedBy;
    public DateTime? Modified;
    public Guid? ModifiedBy;

    protected Auditable()
    {
    }

    protected Auditable(Guid? id) : base(id)
    {
    }
}
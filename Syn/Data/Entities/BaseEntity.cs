namespace Syn.Data.Entities;

public abstract class BaseEntityWithIntId : BaseEntity
{
    [Key] public int Id { get; set; }
}

public abstract class BaseEntity
{
    public string CreatedBy { get; set; } = "";
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; } = "";
    public DateTime UpdatedOn { get; set; }

    public void SetCreated(string user)
    {
        CreatedBy = UpdatedBy = user;
        CreatedOn = UpdatedOn = DateTime.UtcNow;
    }

    public void SetUpdated(string user)
    {
        UpdatedBy = user;
        UpdatedOn = DateTime.UtcNow;
    }
}

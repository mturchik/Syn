namespace Syn.Models;

public abstract class BaseModelWithId : BaseModel
{
    public int Id { get; set; }
}

public abstract class BaseModel
{
    public DateTime UpdatedOn { get; set; }
    public void SetUpdated()
    {
        UpdatedOn = DateTime.UtcNow;
    }
}

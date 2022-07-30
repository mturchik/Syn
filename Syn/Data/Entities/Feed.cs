namespace Syn.Data.Entities;

public class Feed : BaseEntityWithIntId
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Uri { get; set; } = "";
}

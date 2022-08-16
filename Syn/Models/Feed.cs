namespace Syn.Models;

public class Feed : BaseModelWithId
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Uri { get; set; } = "";
}

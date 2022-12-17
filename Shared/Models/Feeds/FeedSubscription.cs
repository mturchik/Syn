namespace Syn.Shared.Models.Feeds;
public class FeedSubscription
{
	public Guid Id { get; set; }
	public string? Url { get; set; }
	public string? Title { get; set; }
	public string? Link { get; set; }
	public string? Description { get; set; }
	public string? ImageUrl { get; set; }
	public DateTime CreatedOn { get; set; }

	public FeedSubscription()
	{
		Id = Guid.NewGuid();
		CreatedOn = DateTime.UtcNow;
	}

	public FeedSubscription(Feed feed)
	{
		Id = Guid.NewGuid();
		Url = feed.Url;
		Title = feed.Title;
		Link = feed.Link;
		Description = feed.Description;
		ImageUrl = feed.ImageUrl;
		CreatedOn = DateTime.UtcNow;
	}
}

namespace Syn.Shared.Models.Feeds;
public class FeedSubscription
{
	public string Url { get; set; }
	public Feed? LatestFeed { get; set; }
	public DateTime? CreatedAt { get; set; }

	public FeedSubscription()
	{
		Url = string.Empty;
	}

	public FeedSubscription(string url, Feed? latestFeed)
	{
		Url = url;
		LatestFeed = latestFeed;
		CreatedAt = DateTime.UtcNow;
	}
}

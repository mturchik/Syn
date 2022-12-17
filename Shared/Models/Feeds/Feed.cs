namespace Syn.Shared.Models.Feeds;
public class Feed
{
	public string? Url { get; set; }
	public string? Title { get; set; }
	public string? Link { get; set; }
	public string? Description { get; set; }
	public string? Language { get; set; }
	public string? Copyright { get; set; }
	public string? LastUpdatedDateString { get; set; }
	public DateTime? LastUpdatedDate { get; set; }
	public string? ImageUrl { get; set; }
	public IList<FeedItem> Items { get; set; } = new List<FeedItem>();

	public Feed() { }

	public Feed(string url, CodeHollow.FeedReader.Feed codeHollowFeed)
	{
		Url = url;
		Title = codeHollowFeed.Title;
		Link = codeHollowFeed.Link;
		Description = codeHollowFeed.Description;
		Language = codeHollowFeed.Language;
		Copyright = codeHollowFeed.Copyright;
		LastUpdatedDateString = codeHollowFeed.LastUpdatedDateString;
		LastUpdatedDate = codeHollowFeed.LastUpdatedDate;
		ImageUrl = codeHollowFeed.ImageUrl;

		if (codeHollowFeed.Items?.Count > 0)
			foreach (var codeHollowFeedItem in codeHollowFeed.Items)
				Items.Add(new FeedItem(codeHollowFeedItem));
	}
}

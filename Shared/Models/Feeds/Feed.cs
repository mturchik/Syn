namespace Syn.Shared.Models.Feeds;
public class Feed
{
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

	public Feed(CodeHollow.FeedReader.Feed codeHollowFeed)
	{
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

public class FeedItem
{
	public string? Title { get; set; }
	public string? Link { get; set; }
	public string? Description { get; set; }
	public string? PublishingDateString { get; set; }
	public DateTime? PublishingDate { get; set; }
	public string? Author { get; set; }
	public string? Id { get; set; }
	public string? Content { get; set; }
	public ICollection<string> Categories { get; set; } = new List<string>();

	public FeedItem() { }

	public FeedItem(CodeHollow.FeedReader.FeedItem codeHollowFeedItem)
	{
		Title = codeHollowFeedItem.Title;
		Link = codeHollowFeedItem.Link;
		Description = codeHollowFeedItem.Description;
		PublishingDateString = codeHollowFeedItem.PublishingDateString;
		PublishingDate = codeHollowFeedItem.PublishingDate;
		Author = codeHollowFeedItem.Author;
		Id = codeHollowFeedItem.Id;
		Content = codeHollowFeedItem.Content;

		if (codeHollowFeedItem.Categories?.Count > 0)
			foreach (var cat in codeHollowFeedItem.Categories)
				Categories.Add(cat);
	}
}
namespace Syn.Shared.Models.Feeds;

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
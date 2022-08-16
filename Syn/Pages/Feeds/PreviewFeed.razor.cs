using Syn.Models;

namespace Syn.Pages.Feeds;

public partial class PreviewFeed
{
    [Inject] protected ICacheService CacheService { get; set; }

    protected IEnumerable<Feed> FeedSource = new List<Feed>();
    protected Feed? SelectedFeed;
    protected IEnumerable<FeedItem> FeedItems = new List<FeedItem>();

    //protected override void OnInitialized()
    //{
    //    FeedSource = AppData.Get<Feed>();
    //}

    //protected void LoadFeed()
    //{
    //    if (SelectedFeed is null) return;

    //    FeedItems = CacheService.GetOrCreate("LoadFeed-" + SelectedFeed.Uri,
    //        () => new FeedReader().RetrieveFeed(SelectedFeed.Uri) ?? new List<FeedItem>());
    //}
}
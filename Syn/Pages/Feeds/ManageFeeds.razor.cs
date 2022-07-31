using Microsoft.AspNetCore.Components.Authorization;

namespace Syn.Pages.Feeds;

public partial class ManageFeeds
{
    [Inject] protected IAppDataService AppData { get; set; }
    [Inject] protected NotificationService NotificationService { get; set; }
    [CascadingParameter] protected Task<AuthenticationState> AuthState { get; set; }

    protected IEnumerable<Feed> FeedSource = new List<Feed>();
    protected FeedForm FormModel = new();

    protected override void OnInitialized()
    {
        FeedSource = AppData.Get<Feed>();
    }

    protected async Task CreateFeed()
    {
        var entity = FormModel.ToEntity();
        entity.SetCreated((await AuthState)?.User?.Identity?.Name ?? "UserNotFound");

        await AppData.Insert(entity);

        FeedSource = AppData.Get<Feed>();
        FormModel = new();
        NotificationService.Notify(NotificationSeverity.Success, "Feed Created");
    }

    protected async Task DeleteFeed(Feed feed)
    {
        await AppData.Delete(feed);
        FeedSource = AppData.Get<Feed>();
        NotificationService.Notify(NotificationSeverity.Warning, "Feed Deleted");
    }

    protected class FeedForm
    {
        [Required, StringLength(50, ErrorMessage = "Name is too long.")]
        public string Name { get; set; } = "";
        [Required, StringLength(50, ErrorMessage = "Description is too long.")]
        public string Description { get; set; } = "";
        [Required, StringLength(200, ErrorMessage = "Uri is too long."), Url]
        public string Uri { get; set; } = "";

        public Feed ToEntity() => new()
        {
            Name = Name.Trim(),
            Description = Description.Trim(),
            Uri = Uri.Trim()
        };
    }
}
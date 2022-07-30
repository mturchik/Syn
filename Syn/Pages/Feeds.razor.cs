using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Syn.Data;
using Syn.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Syn.Pages;

public partial class Feeds
{
    [Inject] protected IAppRepository AppRepository { get; set; }
    [CascadingParameter] protected Task<AuthenticationState> authState { get; set; }

    protected IEnumerable<Feed> FeedSource = new List<Feed>();
    protected FeedForm FormModel = new();

    protected override void OnInitialized()
    {
        FeedSource = AppRepository.Feeds.ToList();
    }

    protected async Task SaveFeed()
    {
        var entity = FormModel.ToEntity();
        entity.SetCreated((await authState)?.User?.Identity?.Name ?? "UserNotFound");

        await AppRepository.Insert(entity);

        FeedSource = AppRepository.Feeds.ToList();
        FormModel = new();
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
            Name = Name,
            Description = Description,
            Uri = Uri
        };
    }
}
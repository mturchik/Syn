using Syn.Shared.Helpers;
using Syn.Shared.Models.Feeds;

namespace Syn.Client.Services;

public class SubscriptionService : ISubscriptionService
{
	public event EventHandler<List<FeedSubscription>>? SubscriptionsChanged;

	private readonly ILocalStorageService _local;

	public SubscriptionService(ILocalStorageService local)
	{
		_local = local;
	}

	public ValueTask<List<FeedSubscription>> GetSubscriptions() => _local.GetItemAsync<List<FeedSubscription>>(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS));

	public async Task AddSubscription(Feed feed)
	{
		var subscriptions = (await GetSubscriptions()) ?? new List<FeedSubscription>();

		var existing = subscriptions.FirstOrDefault(s => s.Url == feed.Url);
		if (existing is null)
		{
			subscriptions.Add(new FeedSubscription(feed));
			await _local.SetItemAsync(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS), subscriptions);
			SubscriptionsChanged?.Invoke(this, subscriptions);
		}
	}

	public async Task RemoveSubscription(Feed feed)
	{
		var subscriptions = (await GetSubscriptions()) ?? new List<FeedSubscription>();

		var existing = subscriptions.FirstOrDefault(s => s.Url == feed.Url);
		if (existing is not null)
		{
			subscriptions.Remove(existing);
			await _local.SetItemAsync(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS), subscriptions);
			SubscriptionsChanged?.Invoke(this, subscriptions);
		}
	}
}

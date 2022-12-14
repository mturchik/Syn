using Syn.Shared.Helpers;
using Syn.Shared.Models.Feeds;

namespace Syn.Client.Services;

public class SubscriptionService : ISubscriptionService
{
	public event EventHandler<List<FeedSubscription>>? SubscriptionsChanged;

	private readonly ILocalService _local;

	public SubscriptionService(ILocalService local)
	{
		_local = local;
	}

	public ValueTask<List<FeedSubscription>> GetSubscriptions() => _local.Get<List<FeedSubscription>>(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS));

	public async Task UpsertSubscription(string url, Feed feed)
	{
		var subscriptions = (await GetSubscriptions()) ?? new List<FeedSubscription>();

		var existing = subscriptions.FirstOrDefault(s => s.Url == url);
		if (existing is null) subscriptions.Add(new FeedSubscription(url, feed));
		else existing.LatestFeed = feed;

		await _local.Set(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS), subscriptions);
		SubscriptionsChanged?.Invoke(this, subscriptions);
	}

	public async Task RemoveSubscription(string url)
	{
		var subscriptions = (await GetSubscriptions()) ?? new List<FeedSubscription>();

		var existing = subscriptions.FirstOrDefault(s => s.Url == url);
		if (existing is not null) subscriptions.Remove(existing);

		await _local.Set(CacheAccess.GetKey(CacheKey.FEEDS_SUBSCRIPTIONS), subscriptions);
		SubscriptionsChanged?.Invoke(this, subscriptions);
	}
}

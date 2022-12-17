using Syn.Shared.Models.Feeds;

namespace Syn.Client.Services;
public interface ISubscriptionService
{
	event EventHandler<List<FeedSubscription>>? SubscriptionsChanged;
	ValueTask<List<FeedSubscription>> GetSubscriptions();
	Task AddSubscription(Feed feed);
	Task RemoveSubscription(Feed feed);
}
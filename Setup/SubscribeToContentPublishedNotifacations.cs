using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using System.Threading;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace UmbracoOutputCache.Setup
{
	public class SubscribeToContentPublishedNotifacations : INotificationHandler<ContentPublishedNotification>
	{
		private readonly ILogger<SubscribeToContentPublishedNotifacations> _logger;
		private readonly IOutputCacheStore _store;
		public SubscribeToContentPublishedNotifacations(ILogger<SubscribeToContentPublishedNotifacations> logger, IOutputCacheStore store)
		{
			_logger = logger;
			_store = store;
		}

		public void Handle(ContentPublishedNotification notification)
		{
			// Define the cancellation token.
			CancellationTokenSource source = new CancellationTokenSource();
			CancellationToken cancellationToken = source.Token;
			_logger.LogInformation("OutputCache Eviction needs to be done as content has been published.");
			_store.EvictByTagAsync(nameof(OutputCacheComposer), cancellationToken);
		}
	}
}
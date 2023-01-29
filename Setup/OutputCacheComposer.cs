using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Website.Controllers;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using System;
using Umbraco.Cms.Core.Notifications;

namespace UmbracoOutputCache.Setup;
public sealed class OutputCacheComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.Services.Configure<UmbracoPipelineOptions>(options =>
		{
			options.AddFilter(new UmbracoPipelineFilter(
				nameof(OutputCacheComposer),
				applicationBuilder =>
				{
				},
				applicationBuilder =>
				{
					applicationBuilder.UseOutputCache();
				},
				applicationBuilder =>
				{
					// Add your endpoints here..
				}
			));
		});

		// Configure Umbraco Render Controller Type
		builder.Services.Configure<UmbracoRenderingDefaultsOptions>(c =>
		{
			c.DefaultControllerType = typeof(OutputCachedRenderController);
		});
		builder.AddComponent<OutputCacheComponent>();
		builder.Services.AddOutputCache(options =>
		{
			options.AddPolicy(OutputCacheComponent.CachePolicyName, b =>
			{
				b.Expire(TimeSpan.FromSeconds(OutputCacheComponent.CachePolicyLifeSpanInSeconds));
				b.Cache();
				b.Tag(nameof(OutputCacheComposer));
			});
		});
		// Register Notifcation Handlers
		builder.AddNotificationHandler<ContentPublishedNotification, SubscribeToContentPublishedNotifacations>();
	}
}


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Composing;

namespace UmbracoOutputCache.Setup
{
	public sealed class OutputCacheComponent : IComponent
	{
		private readonly IConfiguration _config;
		private readonly ILogger<OutputCacheComponent> _logger;
		public const string CachePolicyName = "DefaultUmbracoOutputCachePolicy";
		public static int CachePolicyLifeSpanInSeconds = 10;
		public OutputCacheComponent(
			IConfiguration config,
			ILogger<OutputCacheComponent> logger)
		{
			_config = config;
			_logger = logger;
		}
		public void Initialize()
		{
			var outputCacheSettings = "OutputCacheSettings";
			var cacheLifeSpanInSeconds = _config.GetValue<int>($"{outputCacheSettings}:CacheLifeSpanInSeconds");
			if (cacheLifeSpanInSeconds == 0)
			{
				cacheLifeSpanInSeconds = 10;
				_logger.LogInformation("No CacheLifeSpanInSeconds in appsettings.json so setting to {0} seconds", cacheLifeSpanInSeconds);
			}
			CachePolicyLifeSpanInSeconds = cacheLifeSpanInSeconds;
			_logger.LogInformation("Setting DefaultControllerType to {0} with OutputCaching for policy {1} with a lifeSpan of {2} seconds", nameof(OutputCachedRenderController), CachePolicyName, cacheLifeSpanInSeconds);
		}

		public void Terminate()
		{
		}
	}
}

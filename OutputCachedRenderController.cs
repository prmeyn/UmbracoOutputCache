using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using UmbracoOutputCache.Setup;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbracoOutputCache
{
	public class OutputCachedRenderController : RenderController
	{
		public OutputCachedRenderController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
		}

		[OutputCache(PolicyName = OutputCacheComponent.CachePolicyName)]
		public override IActionResult Index()
		{
			return base.Index();
		}
	}
}

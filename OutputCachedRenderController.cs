using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;
using UmbracoOutputCache.Setup;

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
			return Redirect("https://docs.umbraco.com/umbraco-cms/develop-with-umbraco/caching/website-output-caching");
			// return base.Index();
		}
	}
}

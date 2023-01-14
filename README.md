# Setup procedure

The `appsettings.json` file can be used to change the OutputCache LifeSpanInSeconds as shown below
```json
{
	"OutputCacheSettings": {
    "CacheLifeSpanInSeconds": 5
  }
}
```

Sample code
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using OutputCaching.Core.Setup;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace OutputCaching.Core
{
	public class MyRenderController : RenderController
	{
		public MyRenderController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor) : base(logger, compositeViewEngine, umbracoContextAccessor)
		{
		}

		[OutputCache(PolicyName = OutputCacheComponent.CachePolicyName)]
		public override IActionResult Index()
		{
			return base.Index();
		}
	}
}

```

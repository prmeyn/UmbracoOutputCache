# Setup procedure

The `appsettings.json` file can be used to change the OutputCache LifeSpanInSeconds as shown below
```json
{
	"OutputCacheSettings":
	{
		"CacheLifeSpanInSeconds": 5
	}
}
```


The following Sample code, will make sure that the output that this controller produces is Cached for 5 seconds and any code in the razor views will not be executed for 5 seconds no matter how many concurrent visitors.
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.Logging;
using OutputCaching.Core.Setup;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace DemoNamespace
{
	public class MyRenderController : RenderController
	{
		public MyRenderController(
			ILogger<MyRenderController> logger,
			ICompositeViewEngine compositeViewEngine,
			IUmbracoContextAccessor umbracoContextAccessor)
			: base(logger, compositeViewEngine, umbracoContextAccessor)
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

# What does this package do?
[Output caching](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/overview?view=aspnetcore-7.0#output-caching) has been introduced in ASP.NET Core 7.0, which means you need to at least be on [version 11 of Umbraco.](https://our.umbraco.com/download/releases/1110)
This feature means that all your server side code like in razor templates will not be excecuted over and over again as you get more concurrent visitors but will be cached for the duration you set, by default this package sets it to 10 seconds.

# Simple setup procedure

Just install the [package](https://www.nuget.org/packages/UmbracoOutputCache), and your default RenderController will have OutputCache enabled with a 10 seconds cache interval, which means you get Caching enabled which just installing the nuget package.

# Advanced setup procedure
The `appsettings.json` file can be used to change the OutputCache LifeSpanInSeconds from the default 10 secoonds as shown below
```json
{
	"OutputCacheSettings":
	{
		"CacheLifeSpanInSeconds": 5
	}
}
```

# Hardcore setup procedure
Since this package is [open source](https://github.com/prmeyn/UmbracoOutputCache), feel free to reference the source code and build your own OutputCach menachanisms. 

The following sample code, will make sure that the output that this controller produces is Cached for the configured cache interval  and any code in the razor views will not be executed for that cache interval no matter how many concurrent visitors.
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
For more details on how to configure your own default RenderController check [the official Umbraco documentaion](https://docs.umbraco.com/umbraco-cms/implementation/default-routing/controller-selection#change-the-default-controllers)
# What does this package do?
[Output caching](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/overview?view=aspnetcore-7.0#output-caching) has been introduced in ASP.NET Core 7.0, which means you need to be on at least [version 11 of Umbraco.](https://our.umbraco.com/download/releases/1110)
This package caches all your server side code like in razor templates so that it is not excecuted over and over again as you get more concurrent visitors but will be cached for the duration you set, by default this package sets it to 10 seconds.
This should help improve the performance of your Umbraco server bringing down CPU utilization etc.

## CacheLifeSpanInSeconds
The default **CacheLifeSpanInSeconds** is 10 seconds, this can be modified using the [Advanced setup procedure](#advanced-setup-procedure)
Its important to note that content changes you do in the Umbraco backoffice will need at least this configured amount of seconds to reflect in your frontend for you end users.

# Simple setup procedure
Just install the [package](https://www.nuget.org/packages/UmbracoOutputCache), and your default RenderController will have OutputCache enabled with a 10 seconds cache interval, which means you get OutputCaching enabled by just installing the package.

# Advanced setup procedure
The `appsettings.json` file can be used to change the OutputCache LifeSpanInSeconds from the default 10 seconds to 5 seconds as shown below
```json
{
	"OutputCacheSettings":
	{
		"CacheLifeSpanInSeconds": 5
	}
}
```

# Hardcore setup procedure
Since this package is [open source](https://github.com/prmeyn/UmbracoOutputCache), feel free to reference the source code and build your own OutputCache menachanisms. 

For more details on how to configure your own default RenderController check [the official Umbraco documentaion](https://docs.umbraco.com/umbraco-cms/implementation/default-routing/controller-selection#change-the-default-controllers)

# Want to sponsor?
This is a free package, but if you want to sponsor my open source work, here is [my GitHub profile](https://github.com/sponsors/prmeyn)
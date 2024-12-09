using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

namespace DatetimeSender.Tests;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureWebHost(webHost =>
        {
            webHost.UseEnvironment("Testing");
        });

        return base.CreateHost(builder);
    }
}

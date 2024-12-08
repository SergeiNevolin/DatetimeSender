using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DatetimeSender.Hubs;
using DatetimeSender.Services;
using DatetimeSender.BackgroundTasks;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapHub<MessageHub>("/messageHub");

app.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddSignalR();
    services.AddSingleton<IMessageService, MessageService>();
    services.AddHostedService<MessageBackgroundTask>();
}

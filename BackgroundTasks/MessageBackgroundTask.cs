using Microsoft.AspNetCore.SignalR;
using DatetimeSender.Hubs;
using DatetimeSender.Services;
using DatetimeSender.DTOs;

namespace DatetimeSender.BackgroundTasks;

public class MessageBackgroundTask : BackgroundService
{
    private readonly IHubContext<MessageHub> _hubContext;
    private readonly IMessageService _messageService;

    public MessageBackgroundTask(IHubContext<MessageHub> hubContext, IMessageService messageService)
    {
        _hubContext = hubContext;
        _messageService = messageService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            MessageDto message = _messageService.GenerateMessage();
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            await Task.Delay(3000, stoppingToken);
        }
    }
}

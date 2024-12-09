using DatetimeSender.DTOs;
using Microsoft.AspNetCore.SignalR.Client;

namespace DatetimeSender.Tests;

public class MessageBackgroundTaskIntegrationTests(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory = factory;

    [Fact]
    public async Task MessageBackgroundTask_ShouldSendMessagesPeriodically()
    {
        // Arrange
        var client = _factory.CreateDefaultClient();
        var baseAddress = _factory.Server.BaseAddress.ToString();
        var connection = new HubConnectionBuilder()
            .WithUrl($"{baseAddress}messageHub", options => options.HttpMessageHandlerFactory = _ => _factory.Server.CreateHandler())
            .Build();

        var receivedMessages = new List<MessageDto>();

        connection.On<MessageDto>("ReceiveMessage", message =>
        {
            lock (receivedMessages)
            {
                receivedMessages.Add(message);
            }
        });

        await connection.StartAsync();

        // Act
        await Task.Delay(10000);

        // Assert
        lock (receivedMessages)
        {
            Assert.True(receivedMessages.Count > 2, "Expected to receive at least 3 messages in 10 seconds.");
            foreach (var message in receivedMessages)
            {
                Assert.NotNull(message);
                Assert.False(string.IsNullOrWhiteSpace(message.Content));
                Assert.True(message.Timestamp > DateTime.MinValue);
            }
        }

        // Cleanup
        await connection.DisposeAsync();
    }
}

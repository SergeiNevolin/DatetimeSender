using DatetimeSender.DTOs;

namespace DatetimeSender.Services;

public class MessageService : IMessageService
{
    public MessageDto GenerateMessage()
    {
        var now = DateTime.Now;
        var digits = now.ToString("yyyyMMddHHmmss").Select(c => c - '0');
        int evenCount = digits.Count(d => d % 2 == 0);
        int oddCount = digits.Count() - evenCount;

        string content = evenCount > oddCount ? "чет!" :
                            oddCount > evenCount ? "нечет!" : "равно!";

        return new MessageDto
        {
            Content = content,
            Timestamp = now
        };
    }
}

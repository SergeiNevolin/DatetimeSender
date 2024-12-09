using DatetimeSender.DTOs;

namespace DatetimeSender.Services;

public interface IMessageService
{
    MessageDto GenerateMessage();
}

namespace DatetimeSender.DTOs;

public class MessageDto
{
    public required string Content { get; set; }
    public DateTime Timestamp { get; set; }
}

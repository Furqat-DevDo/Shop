namespace Shop.Application.Emails.Models;

public class EmailSendRequest
{
    public required string To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
}

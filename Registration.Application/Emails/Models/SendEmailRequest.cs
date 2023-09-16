namespace Registration.Application.Emails.Models;

public class SendEmailRequest
{
    public required string To { get; set; }
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
}

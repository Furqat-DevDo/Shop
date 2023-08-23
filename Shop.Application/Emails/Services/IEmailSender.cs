using Shop.Application.Emails.Models;

namespace Shop.Application.Emails.Services;

public interface IEmailSender
{
    Task<SenderResponse> SendEmailAsync(EmailSendRequest request);
}

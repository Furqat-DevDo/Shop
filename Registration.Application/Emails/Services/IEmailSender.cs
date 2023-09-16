using Registration.Application.Emails.Models;

namespace Registration.Application.Emails.Services;

public interface IEmailSender
{
    Task<SenderResponse> SendEmailAsync(SendEmailRequest request);
}

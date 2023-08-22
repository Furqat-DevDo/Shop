namespace Shop.Application.Emails.Services;

public interface IEmailSender
{
    Task SendEmailAsync(string email);
}

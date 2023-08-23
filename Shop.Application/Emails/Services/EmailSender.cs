using Microsoft.Extensions.Logging;
using Shop.Application.Clients;

namespace Shop.Application.Emails.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly ISenderClient _client;
    public EmailSender(ILogger<EmailSender> logger,
        ISenderClient client)
    {
        _logger = logger;
        _client = client;
    }
    public async Task SendEmailAsync(string email)
    {
        //var sendResult = await _client.SendAsync(email);

        throw new NotImplementedException();
    }
}

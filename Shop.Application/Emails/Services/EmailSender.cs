using Microsoft.Extensions.Logging;
using Shop.Application.Clients;
using Shop.Application.Emails.Models;

namespace Shop.Application.Emails.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly ISenderClient<SenderResponse, EmailSendRequest> _client;
    public EmailSender(
        ILogger<EmailSender> logger,
        ISenderClient<SenderResponse, EmailSendRequest> client)
    {
        _logger = logger;
        _client = client;
    }
    public async Task<SenderResponse> SendEmailAsync(EmailSendRequest request)
    {
        var sendResult = await _client.SendAsync(request);
        return sendResult;
    }
}

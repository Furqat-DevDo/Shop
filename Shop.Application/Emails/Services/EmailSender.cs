using Microsoft.Extensions.Logging;
using Registration.Services;
using Shop.Application.Clients;
using Shop.Application.Emails.Models;
using System.Text.Json;

namespace Shop.Application.Emails.Services;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;
    private readonly ISenderClient<SenderResponse, SendEmailRequest> _client;
    public EmailSender(
        ILogger<EmailSender> logger,
        ISenderClient<SenderResponse, SendEmailRequest> client)
    {
        _logger = logger;
        _client = client;
    }
    public async Task<SenderResponse> SendEmailAsync(SendEmailRequest request)
    {
        if (request is null)
        {
            _logger.LogError("Request body was null !!!");
            throw new WrongInputException(nameof(SendEmailRequest));
        }

        var sendResult = await _client.SendAsync(request);

        _logger.LogInformation(JsonSerializer.Serialize(sendResult,new JsonSerializerOptions()
        {
            WriteIndented = true,
        }));

        return sendResult;
    }
}

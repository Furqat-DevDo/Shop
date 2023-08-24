using Microsoft.Extensions.Logging;
using Registration.Services;
using Shop.Application.Clients;
using Shop.Application.Emails.Models;
using Shop.Application.SMS.Models;
using System.Text.Json;

namespace Shop.Application.SMS.Services;
public class SMS_Sender : ISMS_Sender
{
    private readonly ILogger<SMS_Sender> _logger;

    private readonly ISenderClient<SenderResponse,SendSMSRequest> _senderClient;
    public SMS_Sender(ILogger<SMS_Sender> logger, 
        ISenderClient<SenderResponse, SendSMSRequest> senderClient)
    {
        _logger = logger;
        _senderClient = senderClient;
    }
    public Task<SenderResponse> SendMessageAsync(SendSMSRequest request)
    {
        if(request is null)
        {
            _logger.LogError("Request is null !!!!");
            throw new WrongInputException("Request is null !!!!");
        }

        var response = _senderClient.SendAsync(request);

        _logger.LogInformation(JsonSerializer.Serialize(response,
            new JsonSerializerOptions
            {
                WriteIndented = true,
            }));
        return response;
    }
}

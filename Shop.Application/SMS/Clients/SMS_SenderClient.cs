using Microsoft.Extensions.Logging;
using Shop.Application.Clients;
using Shop.Application.Emails.Models;
using Shop.Application.SMS.Models;

namespace Shop.Application.SMS.Clients;

public class SMS_SenderClient :HttpClient,ISenderClient<SenderResponse, SendSMSRequest>
{
    private readonly ILogger<SMS_SenderClient> _logger;

    public SMS_SenderClient(ILogger<SMS_SenderClient> logger)
    {
        _logger = logger;

    }
    public Task<SenderResponse> SendAsync(SendSMSRequest request)
    {
        throw new NotImplementedException();
    }
}

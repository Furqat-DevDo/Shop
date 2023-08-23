using Shop.Application.Emails.Models;
using Shop.Application.SMS.Models;

namespace Shop.Application.SMS.Services;

public interface ISMS_Sender
{
    Task<SenderResponse> SendMessageAsync(SendSMSRequest request);
}

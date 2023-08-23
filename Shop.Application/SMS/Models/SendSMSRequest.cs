namespace Shop.Application.SMS.Models;

public class SendSMSRequest
{
    public required string Phone { get; set; }
    public required string Message { get; set; }
}
namespace Registration.Application.Emails.Models;

public class SenderResponse
{
    public int StatusCode { get; set; }
    public string? ExceptionMessage { get; set; }
    public bool IsSuccess { get; set; }
}

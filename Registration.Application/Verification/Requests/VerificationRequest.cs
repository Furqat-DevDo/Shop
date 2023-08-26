using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Verification.Requests;

public class VerificationRequest
{
    [EmailAddress]
    public required string Email { get; set; }

    [MinLength(4)]
    public required string Code { get; set; }
}

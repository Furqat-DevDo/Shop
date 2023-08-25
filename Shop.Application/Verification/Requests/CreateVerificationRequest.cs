using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Verification.Requests;

public class CreateVerificationRequest
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [MinLength(4)]
    public required string Code { get; set; }
}

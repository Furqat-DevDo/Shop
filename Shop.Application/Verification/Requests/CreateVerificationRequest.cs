
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Verification.Requests;

public class CreateVerificationRequest
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [VerificationCode]
    public required int VerificationCode { get; set; }
}

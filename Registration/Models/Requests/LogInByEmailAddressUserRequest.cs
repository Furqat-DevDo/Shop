using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class LogInByEmailAddressUserRequest
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [MinLength(5, ErrorMessage = "Minimal length of password is 5 !!!")]
    public required string Password { get; set; }
}

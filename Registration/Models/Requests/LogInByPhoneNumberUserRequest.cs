using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class LogInByPhoneNumberUserRequest
{
    [Phone]
    public required string PhoneNumber { get; set; }

    [NotNull, MinLength(5, ErrorMessage = "Minimal length of password is 5 !!!")]
    public required string Password { get; set; }
}

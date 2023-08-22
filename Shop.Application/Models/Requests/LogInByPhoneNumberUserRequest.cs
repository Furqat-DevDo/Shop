using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class LogInByPhoneNumberUserRequest
{
    [Phone]
    public required string PhoneNumber { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

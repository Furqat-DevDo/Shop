using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class LogInByEmailAddressUserRequest
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

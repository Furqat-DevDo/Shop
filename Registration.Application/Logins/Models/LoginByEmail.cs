using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Registration.Application.Attributes;

namespace Registration.Application.Logins.Models;

public class LoginByEmail
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Application.Logins.Models;

public class LoginByEmail
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

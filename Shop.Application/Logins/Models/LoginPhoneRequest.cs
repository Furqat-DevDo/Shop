using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Logins.Models;

public class LoginPhoneRequest
{
    [Phone]
    public required string PhoneNumber { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

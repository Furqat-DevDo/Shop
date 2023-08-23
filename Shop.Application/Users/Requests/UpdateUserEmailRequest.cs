using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Users.Requests;

public class UpdateUserEmailRequest
{
    public required string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [EmailAddress]
    public required string EmailAddress { get; set; }
}

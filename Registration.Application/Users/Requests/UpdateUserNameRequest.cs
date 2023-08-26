using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Users.Requests;

public class UpdateUserNameRequest
{
    public required string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [NameValidator]
    public required string FullName { get; set; }
}

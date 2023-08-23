using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Users.Requests;

public class UpdateUserRequest
{
    public required string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
    public required string NameOfUserAuthData { get; set; }

    public required string NewUserAuthData { get; set; }
}

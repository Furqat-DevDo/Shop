using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Users.Requests;

public class UpdateUserPhoneRequest
{
    public required string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [PhoneNumberValidator]
    public required string PhoneNumber { get; set; }
}

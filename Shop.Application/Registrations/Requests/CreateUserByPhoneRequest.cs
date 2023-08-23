using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Registrations.Requests;

public class CreateUserByPhoneRequest
{
    [NameValidator]
    public required string FullName { get; set; }

    [PhoneNumberValidator]
    public required string PhoneNumber { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

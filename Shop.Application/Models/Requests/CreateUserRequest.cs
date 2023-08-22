using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Registration.Models.Requests;

public class CreateUserRequest
{
    [NameValidator]
    public required string FullName { get; set; }

    [EmailAddress]
    public required string EmailAddress { get; set; }

    [PhoneNumberValidator]
    public required string PhoneNumber { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Registrations.Models;

public class RegisterRequest
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

using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Registrations.Requests;

public class CreateUserRequest
{
    [NameValidator]
    public required string FullName { get; set; }

    [EmailAddress]
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

using System.ComponentModel.DataAnnotations;
using Registration.Application.Attributes;

namespace Registration.Application.Users.Requests;

public class UpdateUserDataRequest
{
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [EmailAddress]
    public required string NewEmailAddress { get; set; }

    [NameValidator]
    public required string NewFullName { get; set; }
}

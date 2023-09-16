using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Registration.Application.Attributes;

namespace Registration.Application.Users.Requests;

public class UpdateUserPassRequest
{
    [NotNull]
    public required string EmailAddress { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string NewPassword { get; set; }
}

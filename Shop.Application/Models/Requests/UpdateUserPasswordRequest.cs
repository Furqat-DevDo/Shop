using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class UpdateUserPasswordRequest
{
    [NotNull]
    public string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string NewPassword { get; set; }
}

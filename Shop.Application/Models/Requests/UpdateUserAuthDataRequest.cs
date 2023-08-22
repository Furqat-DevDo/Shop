using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Models.Requests;

public partial class UpdateUserAuthDataRequest
{
    public required string UserAuthData { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }

    [EnumDataType(typeof(EFixedStrings), ErrorMessage = "Invalid fixed string value.")]
    public required string NameOfUserAuthData { get; set; }
    
    public required string NewUserAuthData { get; set; }
}

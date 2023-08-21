using System.ComponentModel.DataAnnotations;

namespace Registration_user.UserModel.Request;

public class UserLogInByPhoneNumberRequest
{
    [Required]
    [Phone]
    public int PhoneNumber { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Password { get; set; }
}

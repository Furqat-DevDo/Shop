using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration_user.UserModel.Request;

public class UserLogInResponse
{
    public string Id { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [PasswordPropertyText]
    public string Password { get; set; }
}

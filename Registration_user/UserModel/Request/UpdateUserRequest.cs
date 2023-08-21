using System.ComponentModel.DataAnnotations;

namespace Registration_user.UserModel.Request;

public class UpdateUserRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
}

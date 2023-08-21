﻿using System.ComponentModel.DataAnnotations;

namespace Registration_user.UserModel.Request;

public class UserLogInByEmailRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Password { get; set; }
}

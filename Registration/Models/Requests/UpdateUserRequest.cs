﻿using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class UpdateUserRequest
{
    [NotNull]
    public string UserAuthData { get; set; }

    [NotNull, MinLength(5, ErrorMessage = "Minimal length of password is 5 !!!")]
    public required string NewPassword { get; set; }
}

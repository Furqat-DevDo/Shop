﻿using Registration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Registration.Models.Requests;

public class CreateUserRequest
{
    [NameValidator]
    public required string FullName { get; set; }

    [EmailValidator]
    public required string EmailAddress { get; set; }

    [PhoneNumberValidator]
    public required string PhoneNumber { get; set; }

    [NotNull, MinLength(5, ErrorMessage = "Minimal length of password is 5 !!!")]
    public required string Password { get; set; }
}
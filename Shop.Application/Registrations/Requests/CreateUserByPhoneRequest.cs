using Registration.Attributes;
using System.ComponentModel.DataAnnotations;

<<<<<<<< HEAD:Shop.Application/Registrations/Models/RegisterRequest.cs
namespace Shop.Application.Registrations.Models;

public class RegisterRequest
========
namespace Shop.Application.Registrations.Requests;

public class CreateUserByPhoneRequest
>>>>>>>> c912c01f750b35b7ce32f13c20143b1bf012fb88:Shop.Application/Registrations/Requests/CreateUserByPhoneRequest.cs
{
    [NameValidator]
    public required string FullName { get; set; }

    [PhoneNumberValidator]
    public required string PhoneNumber { get; set; }

    [PasswordValidator]
    [Display(Name = "Password")]
    public required string Password { get; set; }
}

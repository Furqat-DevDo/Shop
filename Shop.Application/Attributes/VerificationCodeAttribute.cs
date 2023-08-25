using System.ComponentModel.DataAnnotations;

namespace Shop.Application.Verification.Requests;

public class VerificationCodeAttribute : ValidationAttribute
{
    private readonly int _minimalCodeValue = 1000;

    public VerificationCodeAttribute() { }

    public VerificationCodeAttribute(int minimalCodeValue) 
    {
        _minimalCodeValue = minimalCodeValue;
    }

    public bool IsValid(object? value)
    => value is not null && (int) value >= _minimalCodeValue;

    public override string FormatErrorMessage(string name = "")
    {
        return $"The verification code {name} is not valid";
    }
}
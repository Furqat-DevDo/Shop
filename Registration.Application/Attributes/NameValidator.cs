using System.ComponentModel.DataAnnotations;
using Registration.Application.Attributes;

namespace Registration.Application.Attributes;

public class NameValidator : ValidationAttribute
{
    public int MinLength { get; set; } = 3;
    public int MaxLength { get; set; } = 60;

    public NameValidator() { }

    public NameValidator(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }

    public NameValidator(int minLength, int maxLength, string ErrorMessage) : this(minLength, maxLength)
    {
    }

    public override bool IsValid(object? value)
    {
        return !string.IsNullOrEmpty(value as string) && value is string text && text.Length >= MinLength && text.Length <= MaxLength;
    }

    public override string FormatErrorMessage(string message)
    {
        return $"The lengts of Full Name should be " +
            $"(Min = {MinLength} and Max = {MaxLength})";
    }
}

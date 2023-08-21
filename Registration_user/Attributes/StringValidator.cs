using System.ComponentModel.DataAnnotations;

namespace EfCore.Attributes;

/// <summary>
/// Validates that a string value is between a minimum and maximum length.
/// </summary>
public class StringValidator : ValidationAttribute
{
    public int MinLength { get; set; } = 1;
    public int MaxLength { get; set; } = 1000;

    public StringValidator() { }

    public StringValidator(int minLength, int maxLength)
    {
        MinLength = minLength;
        MaxLength = maxLength;
    }

    public StringValidator(int minLength, int maxLength, string ErrorMessage) : this(minLength, maxLength)
    {
    }

    public override bool IsValid(object? value)
    {
        return !string.IsNullOrEmpty(value as string) && value is string text && text.Length >= MinLength && text.Length <= MaxLength;
    }

    public override string FormatErrorMessage(string message)
    {
        return $"The lengts of {message} should be " +
            $"(MinLength: {MinLength}, MaxLength: {MaxLength})";
    }
}
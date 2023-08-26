using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Registration.Attributes;

public class PhoneNumberValidator : ValidationAttribute
{
    public PhoneNumberValidator() { }

    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;

        Regex regex = new Regex(@"^\+?\d{1,4}?[-\s]?\(?\d{1,4}?\)?[-\s]?\d{1,4}[-\s]?\d{1,6}[-\s]?\d{1,6}$", RegexOptions.Compiled);
        return regex.IsMatch((string)value);
    }

    public override string FormatErrorMessage(string message = "")
    {
        return $"The phone number {message} is not valid";
    }
}
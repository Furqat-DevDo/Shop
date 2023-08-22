using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Registration.Attributes;

public class PasswordValidator : ValidationAttribute
{
    public PasswordValidator() { }

    public override bool IsValid(object? value)
    {
        if (value is null)
            return false;

        string strValue = (string)value;
        if(strValue.Length < 5)
            return false;

        string pattern = @"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(strValue);
    }

    public override string FormatErrorMessage(string message = "")
    {
        return $"The given password {message} is not valid. " +
            $"Please write minimum 5 characters !!!";
    }
}

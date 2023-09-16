using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Registration.Application.Attributes;

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

        Regex regex = new Regex(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", RegexOptions.Compiled);
        return regex.IsMatch(strValue);
    }

    public override string FormatErrorMessage(string message = "")
    {
        return $"The given password {message} is not valid. " +
            $"Please write combination of minimum 5 characters, uppercase letters and numbers!!!";
    }
}

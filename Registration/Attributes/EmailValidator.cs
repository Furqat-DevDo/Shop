using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Registration.Attributes;

public class EmailValidator : ValidationAttribute
{
    public EmailValidator() { }

    public override bool IsValid(object value)
    {
        string email = value.ToString();

        // Basic format validation
        if (!IsValidFormat(email))
            return false;

        // Domain and DNS validation
        if (!IsValidDomain(email))
            return false;

        return true;
    }

    private bool IsValidFormat(string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }

    private bool IsValidDomain(string email)
    {
        try
        {
            var domain = email.Split('@')[1];
            var domainEntry = Dns.GetHostEntry(domain);
            return domainEntry.AddressList.Length > 0;
        }
        catch
        {
            return false;
        }
    }
}

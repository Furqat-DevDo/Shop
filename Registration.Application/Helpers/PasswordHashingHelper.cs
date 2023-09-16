using System.Security.Cryptography;
using System.Text;

namespace Registration.Application.Helpers;

public static class PasswordHashingHelper
{
    public static string PasswordHashing(string value)
    {
        var sha1 = SHA256.Create();

        var inputBytes = Encoding.ASCII.GetBytes(value);

        var hash = sha1.ComputeHash(inputBytes);

        var sb = new StringBuilder();

        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }
}

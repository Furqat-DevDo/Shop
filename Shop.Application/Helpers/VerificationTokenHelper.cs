namespace Shop.Application.Helpers;

public static class VerificationTokenHelper
{
    public static string CreateToken(string email, int code)
    {
        return "Verified:" + email + code.ToString();
    }
}

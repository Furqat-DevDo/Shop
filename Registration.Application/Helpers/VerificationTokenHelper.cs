namespace Registration.Application.Helpers;

public static class VerificationTokenHelper
{
    public static string CreateToken(string email, string code)
    {
        return "Verified:" + email + code;
    }
}

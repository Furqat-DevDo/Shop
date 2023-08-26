using Shop.Application.Helpers;
using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;
using Shop.Core.Entities;

namespace Shop.Application.Verification.Mappers;

public static class VerificationMapper
{
    public static VerificationEntity CreateVerification(this VerificationRequest request)
        => new VerificationEntity
        {
            EmailAddress = request.Email,
            Code = request.Code,
        };

    public static void UpadateVerification(this VerificationEntity verification, 
        VerificationRequest request)
    {
        verification.Code = request.Code;
    }

    public static ResponceVerification ResponseVerification(this VerificationEntity verification)
        => new ResponceVerification
        {
            VerficationToken = VerificationTokenHelper.CreateToken(verification.EmailAddress, verification.Code)
        };
}

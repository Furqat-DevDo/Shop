using Registration.Application.Helpers;
using Registration.Application.Verification.Requests;
using Registration.Application.Verification.Responses;
using Registration.Core.Entities;

namespace Registration.Application.Verification.Mappers;

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

    public static ResponseVerification ResponseVerification(this VerificationEntity verification)
        => new ResponseVerification
        {
            VerficationToken = VerificationTokenHelper.CreateToken(verification.EmailAddress, verification.Code)
        };
}

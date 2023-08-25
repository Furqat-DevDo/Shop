﻿using Shop.Application.Helpers;
using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;
using Shop.Core.Entities;

namespace Shop.Application.Verification.Mappers;

public static class VerificationMapper
{
    public static VerificationEntity CreateVerification(this CreateVerificationRequest request)
        => new VerificationEntity
        {
            EmailAddress = request.EmailAddress,
            Code = request.Code,
        };

    public static void UpadateVerification(this VerificationEntity verification, CreateVerificationRequest request)
    {
        verification.Code = request.Code;
    }

    public static ResponceVerification ResponseVerification(this VerificationEntity verification)
        => new ResponceVerification
        {
            VerficationToken = VerificationTokenHelper.CreateToken(verification.EmailAddress, verification.Code)
        };
}

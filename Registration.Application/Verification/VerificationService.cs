using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Registration.Core.Entities;
using Registration.Application.Exceptions;
using Registration.Application.Helpers;
using Registration.Application.Verification.Mappers;
using Registration.Application.Verification.Requests;
using Registration.Application.Verification.Responses;
using Registration.Core.Data;

namespace Registration.Application.Verification;

public class VerificationService : IVerificationService
{
    private readonly RegDbContext _dbContext;
    private readonly ILogger<VerificationService> _logger;

    public VerificationService(RegDbContext dbContext, ILogger<VerificationService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<ResponseVerification> CreateVerificationAsync(
        VerificationRequest request)
    {
        if (request is null) DoIfRequestIsNull();

        var verificationOrNull = await _dbContext.Verifications 
            .FirstOrDefaultAsync(v => v.EmailAddress == request.Email);

        if (verificationOrNull is not null)
            return await UpdateVerificationAsync(verificationOrNull, request);

        var verification = request.CreateVerification();
        var newVerification = await _dbContext.Verifications.AddAsync(verification);
        await TrySaveDbChanges();
        return newVerification.Entity.ResponseVerification();
    }

    public async Task<ResponseVerification> PasswordUpdateVerificationAsync(
        VerificationRequest request,
        string newPassword)
    {
        //if (request is null) DoIfRequestIsNull();
        ArgumentNullException.ThrowIfNull(request,nameof(request));

        var verification = await _dbContext.Verifications
            .FirstOrDefaultAsync(v => v.EmailAddress == request.Email);
        if (verification is null)
        {
            _logger.LogError("Invalid verification request.");
            throw new WrongInputException("Something went wrong. Please try again !!!");
        }

        //Writing to PasswordUpdate table new password
        var passwordUpdate = await _dbContext.PasswordUpdates
            .FirstOrDefaultAsync(f => f.EmailAddress == request.Email);
        if(passwordUpdate is null)
        {
            await _dbContext.PasswordUpdates.AddAsync(new PasswordUpdate
            {
                EmailAddress = request.Email,
                NewPassword = PasswordHashingHelper.PasswordHashing(newPassword)
            });
            await TrySaveDbChanges();
        }
        else
        {
            passwordUpdate.NewPassword = PasswordHashingHelper.PasswordHashing(newPassword);
            _dbContext.PasswordUpdates.Update(passwordUpdate);
            await TrySaveDbChanges();
        }

        return await UpdateVerificationAsync(verification, request);
    }

    public async Task<ResponseVerification> VerifyUserAsync(VerificationRequest request)
    {
        if (request is null) DoIfRequestIsNull();

        var verification = await _dbContext.Verifications
            .AsNoTracking()
            .FirstOrDefaultAsync(v =>
            v.EmailAddress == request.Email);

        if (verification is null || verification.Code != request.Code)
        {
            _logger.LogError("Invalid verification request.");
            throw new WrongInputException("Something went wrong. Please try again !!!");
        }

        //if user tried to update its password, updating it
        var passwordUpdate = await _dbContext.PasswordUpdates
            .FirstOrDefaultAsync(f => f.EmailAddress == request.Email);
        if (passwordUpdate is not null && passwordUpdate.NewPassword is not null)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(f => f.EmailAddress == request.Email);

            user.Password = passwordUpdate.NewPassword;
            _dbContext.Users.Update(user);
            passwordUpdate.NewPassword = null;
            _dbContext.PasswordUpdates.Update(passwordUpdate);
            await TrySaveDbChanges();
        }

        return verification.ResponseVerification();
    }

    private async Task<ResponseVerification> UpdateVerificationAsync(
        VerificationEntity verification,
        VerificationRequest request)
    {
        verification.UpadateVerification(request);
        _dbContext.Verifications.Update(verification);
        await TrySaveDbChanges();
        return verification.ResponseVerification();
    }

    private async Task TrySaveDbChanges()
    {
        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");
    }

    private void DoIfRequestIsNull()
    {
        _logger.LogError("Invalid verification request.");
        throw new WrongInputException("Something went wrong. Please try again !!!");
    }
}

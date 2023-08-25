using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Registration.Exceptions;
using Registration.Services;
using Shop.Application.Verification.Mappers;
using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;
using Shop.Core.Data;

namespace Shop.Application.Verification;

public class VerificationService : IVerificationService
{
    private readonly RegDbContext _dbContext;
    private readonly ILogger<VerificationService> _logger;

    public VerificationService(RegDbContext dbContext, ILogger<VerificationService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<ResponceVerification> CreateVerificationAsync(CreateVerificationRequest request)
    {
        if (request is null)
        {
            _logger.LogError("Invalid verification request.");
            throw new WrongInputException("Something went wrong. Please try again !!!");
        }
            
        var verificationCheck = await _dbContext.Verifications.FirstOrDefaultAsync(v => 
            v.EmailAddress == request.EmailAddress);
        
        if(verificationCheck is not null)
        {
            verificationCheck.UpadateVerification(request);
            _dbContext.Verifications.Update(verificationCheck);
            await TrySaveDbChanges();
            return verificationCheck.ResponseVerification();
        }

        var verification = request.CreateVerification();
        var newVerification = await _dbContext.Verifications.AddAsync(verification);

        await TrySaveDbChanges();
        return newVerification.Entity.ResponseVerification();
    }

    public async Task<ResponceVerification> VerifyUserAsync(GetVerificationRequest request)
    {
        if (request is null)
        {
            _logger.LogError("Invalid verification request.");
            throw new WrongInputException("Something went wrong. Please try again !!!");
        }

        var verification = await _dbContext.Verifications.FirstOrDefaultAsync(v => 
            v.EmailAddress == request.EmailAddress);

        if(verification is null || verification.Code != request.Code)
        {
            _logger.LogError("Invalid verification request.");
            throw new WrongInputException("Something went wrong. Please try again !!!");
        }

        return verification.ResponseVerification();
    }

    private async Task TrySaveDbChanges()
    {
        if (await _dbContext.SaveChangesAsync() <= 0)
            throw new UnableToSaveUserChangesException("Internal Server Error");
    }
}

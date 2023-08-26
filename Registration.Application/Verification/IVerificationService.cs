using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;

namespace Shop.Application.Verification;

public interface IVerificationService
{
    public Task<ResponceVerification> CreateVerificationAsync(VerificationRequest request);
    public Task<ResponceVerification> VerifyUserAsync(VerificationRequest request);
}

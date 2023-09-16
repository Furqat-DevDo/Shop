using Registration.Application.Verification.Requests;
using Registration.Application.Verification.Responses;

namespace Registration.Application.Verification;

public interface IVerificationService
{
    public Task<ResponseVerification> CreateVerificationAsync(
        VerificationRequest request);
    public Task<ResponseVerification> VerifyUserAsync(
        VerificationRequest request);
    public Task<ResponseVerification> PasswordUpdateVerificationAsync(
        VerificationRequest request, string newPassword);
}

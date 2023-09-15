using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;

namespace Shop.Application.Verification;

public interface IVerificationService
{
    public Task<ResponseVerification> CreateVerificationAsync(
        VerificationRequest request);
    public Task<ResponseVerification> VerifyUserAsync(
        VerificationRequest request);
    public Task<ResponseVerification> PasswordUpdateVerificationAsync(
        VerificationRequest request, string newPassword);
}

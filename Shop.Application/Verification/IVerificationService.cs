using Shop.Application.Users.Responces;
using Shop.Application.Verification.Requests;
using Shop.Application.Verification.Responces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Verification;

public interface IVerificationService
{
    public Task<ResponceVerification> CreateVerificationAsync(CreateVerificationRequest request);
    public Task<ResponceVerification> VerifyUserAsync(GetVerificationRequest request);
}

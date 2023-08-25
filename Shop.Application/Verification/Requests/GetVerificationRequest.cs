using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Verification.Requests;

public class GetVerificationRequest
{
    [EmailAddress]
    public required string EmailAddress { get; set; }

    [VerificationCode]
    public required int Code { get; set; }
}

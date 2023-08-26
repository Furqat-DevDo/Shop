using Microsoft.AspNetCore.Mvc;
using Shop.Application.Verification;
using Shop.Application.Verification.Requests;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationsController : ControllerBase
    {
        [HttpPut]
        public async ValueTask<IActionResult> VerifyUserAsync(
        VerificationRequest request,
        [FromServices] IVerificationService verificationService)
        {
            var response = await verificationService.VerifyUserAsync(request);
            return Ok(response);
        }

        [HttpGet]
        public async ValueTask<IActionResult> CreateOrUpdate (
            [FromQuery]VerificationRequest request
            , [FromServices] IVerificationService verificationService)
        {
            var result = await verificationService.VerifyUserAsync(request);
            return Ok(result);
        }
    }
}

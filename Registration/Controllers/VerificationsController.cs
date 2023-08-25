using Microsoft.AspNetCore.Mvc;
using Shop.Application.Verification;
using Shop.Application.Verification.Requests;

namespace Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> VerifyUserAsync(
        [FromQuery] CreateVerificationRequest request,
        [FromServices] IVerificationService verificationService)
        {
            var response = await verificationService.VerifyUserAsync(request);
            return Ok(response);
        }
    }
}

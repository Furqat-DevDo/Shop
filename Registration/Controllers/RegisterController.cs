using Microsoft.AspNetCore.Mvc;
using Shop.Application.Registrations.Requests;
using Shop.Application.Registrations.Services;
using Shop.Application.Users.Responces;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    /// <summary>
    /// Here you can register new user by Email Address.
    /// </summary>
    /// <param name="request">Necessary data of new user</param>
    /// <param name="registrationService">Parameter for connecting registration service</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "fullName": "Sample User",
    ///             "emailAddress": "user@example.com",
    ///             "password": "Samplepass1"
    ///         }
    /// </remarks>
    /// <response code="200">Returns the newly registered user</response>
    /// <response code="500">Returns when there was unable to register new user</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("Registration")]
    public async Task<IActionResult> RegisterUserAsync(
        CreateUserRequest registerRequest,
        [FromServices] IRegistrationService registrationService)
    {
        var response = await registrationService.CreateUserAsync(registerRequest);
        return Ok(response);
    }
}

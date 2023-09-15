using Microsoft.AspNetCore.Mvc;
using Shop.Application.Logins.Models;
using Shop.Application.Logins.Services;
using Shop.Application.Registrations.Requests;
using Shop.Application.Registrations.Services;
using Shop.Application.Users.Responces;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    /// <summary>
    /// Here you can login user by Email Address.
    /// </summary>
    /// <param name="loginRequest">Request with Email address and Password of user for identification</param>
    /// <param name="loginService">Parameter for connecting login service</param>
    /// <response code="200">Returns user with given email and password</response>
    /// <response code="400">Returns when given data does not match</response>
    /// <response code="404">Returns when such user was not found</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet("Login")]
    public async Task<IActionResult> LoginUserAsync(
        [FromQuery] LoginByEmail loginRequest,
        [FromServices] ILoginService loginService)
    {
        var response = await loginService.GetUserByEmailAddressAsync(loginRequest);
        return Ok(response);
    }
}

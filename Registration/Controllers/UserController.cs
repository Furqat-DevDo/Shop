using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;
using Shop.Application.Users.Services;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    /// <summary>
    /// Here you can update user's password by entering your email and verificating it.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email the user and for new password</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "emailAddress": "user@example.com",
    ///             "newPassword": "Samplepass2"
    ///         }
    /// </remarks>
    /// <response code="200">Returns user with given email or phone number</response>
    /// <response code="404">Returns when such user was not found</response>
    /// <response code="500">Returns when there was internal server error</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("UpdateUserPassword")]
    public async Task<IActionResult> UpdateUserPasswordAsync(
        UpdateUserPassRequest updateRequest,
        [FromServices]IUserService userService)
    {
        var result = await userService.UpdateUserPasswordAsync(updateRequest);
        return Ok(result);
    }

    /// <summary>
    /// Here you can update user's Full Name and Email Address.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email with password of the user and for new datas</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "userAuthData": "user@example.com",
    ///             "password": "Samplepass1",
    ///             "newEmailAddress": "updatedUser@example.com",
    ///             "newFullName": "Alex Jacob"
    ///         }
    /// </remarks>
    /// <response code="200">Returns user with given email or phone number</response>
    /// <response code="404">Returns when such user was not found</response>
    /// <response code="400">Returns when given data does not match</response>
    /// <response code="500">Returns when there was internal server error</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPut("UpdateUserData")]
    public async Task<IActionResult> UpdateUserNameAsync(
        UpdateUserDataRequest updateRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserDataAsync(updateRequest);
        return Ok(result);
    }
}

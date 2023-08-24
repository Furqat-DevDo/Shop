using Microsoft.AspNetCore.Mvc;
using Shop.Application.Logins.Models;
using Shop.Application.Logins.Services;
using Shop.Application.Registrations.Requests;
using Shop.Application.Registrations.Services;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Responces;
using Shop.Application.Users.Services;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    /// <summary>
    /// Here you can register new user by Phone number.
    /// </summary>
    /// <param name="request">Necessary data of new user</param>
    /// <param name="registrationService">Parameter for connecting registration service</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "fullName": "Sample User",
    ///             "phoneNumber": "991234567",
    ///             "password": "Samplepass1"
    ///         }
    /// </remarks>
    /// <response code="200">Returns the newly registered user</response>
    /// <response code="500">Returns when there was unable to register new user</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [HttpPost("Phone")]
    public async Task<IActionResult> CreateUserPhoneAsync(
        CreateUserByPhoneRequest request,
        [FromServices] IRegistrationService registrationService)
    {
        var response = await registrationService.CreateUserByPhoneAsync(request);
        return Ok(response);
    }

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
    [HttpPost("Email")]
    public async Task<IActionResult> CreateUserEmailAsync(
        CreateUserByEmailRequest request,
        [FromServices] IRegistrationService registrationService)
    {
        var response = await registrationService.CreateUserByEmailAsync(request);
        return Ok(response);
    }

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
    [HttpGet("LoginByEmailAddress")]
    public async Task<IActionResult> LoginByEmailAddressAsync(
        [FromQuery]LoginByEmail loginRequest,
        [FromServices] ILoginService loginService)
    {
        var response = await loginService.GetUserByEmailAddressAsync(loginRequest);
        return Ok(response);
    }

    /// <summary>
    /// Here you can login user by Phone Number.
    /// </summary>
    /// <param name="loginRequest">Request with Phone Number and Password of user for identification</param>
    /// <param name="loginService">Parameter for connecting login service</param>
    /// <response code="200">Returns user with given phone number and password</response>
    /// <response code="400">Returns when given data does not match</response>
    /// <response code="404">Returns when such user was not found</response>
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpGet("LoginByPhoneNumber")]
    public async Task<IActionResult> LoginByPhoneNumberAsync(
        [FromQuery]LoginPhoneRequest loginRequest,
        [FromServices] ILoginService loginService)
    {
        var response = await loginService.GetUserByPhoneNumberAsync(loginRequest);
        return Ok(response);
    }

    /// <summary>
    /// Here you can update user's password.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email or phone the user and for new password</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "userAuthData": "user@example.com",
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
    /// Here you can update user's Full Name.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email or phone with password of the user and for new Full Name</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "userAuthData": "user@example.com",
    ///             "password": "Samplepass1",
    ///             "fullName": "Alex Jacob"
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
    [HttpPut("UpdateUserFullName")]
    public async Task<IActionResult> UpdateUserNameAsync(
        UpdateUserNameRequest updateRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserNameAsync(updateRequest);
        return Ok(result);
    }

    /// <summary>
    /// Here you can update user's Email Address.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email or phone with password of the user and for new Email Address</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "userAuthData": "991234567",
    ///             "password": "Samplepass1",
    ///             "emailAddress": "updateduser@example.com"
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
    [HttpPut("UpdateUserEmailAddress")]
    public async Task<IActionResult> UpdateUserEmailAsync(
        UpdateUserEmailRequest updateRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserEmailAsync(updateRequest);
        return Ok(result);
    }

    /// <summary>
    /// Here you can update user's Phone Number.
    /// </summary>
    /// <param name="updateRequest">Request for identification by email or phone with password of the user and for new Phone Number</param>
    /// <param name="userService">Parameter for connecting update and other user services</param>
    /// <remarks >
    /// Sample request:
    ///
    ///         POST
    ///         {
    ///             "userAuthData": "user@example.com",
    ///             "password": "Samplepass1",
    ///             "phoneNumber": "+998901234567"
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
    [HttpPut("UpdateUserPhoneNumber")]
    public async Task<IActionResult> UpdateUserPhoneAsync(
        UpdateUserPhoneRequest updateRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserPhoneAsync(updateRequest);
        return Ok(result);
    }
}

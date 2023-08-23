﻿using Microsoft.AspNetCore.Mvc;
using Shop.Application.Logins.Models;
using Shop.Application.Logins.Services;
using Shop.Application.Registrations.Models;
using Shop.Application.Registrations.Services;
using Shop.Application.Users.Requests;
using Shop.Application.Users.Services;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(
        RegisterRequest request,
        [FromServices] IRegistrationService registrationService)
    {
        var response = await registrationService.CreateUserAsync(request);
        return Ok(response);
    }

    [HttpGet("GetByEmailAddress")]
    public async Task<IActionResult> GetUserByEmailAddressAsync(
        [FromQuery]LoginByEmail LoginRequest,
        [FromServices] ILoginService loginService)
    {
        var response = await loginService.GetUserByEmailAddressAsync(LoginRequest);
        return Ok(response);
    }

    [HttpGet("GetByPhoneNumber")]
    public async Task<IActionResult> GetUserByPhoneNumberAsync(
        [FromQuery]LoginPhoneRequest phoneRequest,
        [FromServices] ILoginService loginService)
    {
        var response = await loginService.GetUserByPhoneNumberAsync(phoneRequest);
        return Ok(response);
    }

    [HttpPut("UpdateUserPassword")]
    public async Task<IActionResult> UpdateUserPasswordAsync(
        UpdateUserPassRequest passRequest,
        [FromServices]IUserService userService)
    {
        var result = await userService.UpdateUserPasswordAsync(passRequest);
        return Ok(result);
    }

    [HttpPut("UpdateUserFullName")]
    public async Task<IActionResult> UpdateUserNameAsync(
        UpdateUserNameRequest userRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserNameAsync(userRequest);
        return Ok(result);
    }

    [HttpPut("UpdateUserEmailAddress")]
    public async Task<IActionResult> UpdateUserEmailAsync(
        UpdateUserEmailRequest userRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserEmailAsync(userRequest);
        return Ok(result);
    }

    [HttpPut("UpdateUserPhoneNumber")]
    public async Task<IActionResult> UpdateUserPhoneAsync(
        UpdateUserPhoneRequest userRequest,
        [FromServices] IUserService userService)
    {
        var result = await userService.UpdateUserPhoneAsync(userRequest);
        return Ok(result);
    }
}

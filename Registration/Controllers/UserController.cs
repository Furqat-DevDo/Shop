using Microsoft.AspNetCore.Mvc;
using Registration.Models.Requests;
using Registration.Services.Interfaces;

namespace Registration.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(CreateUserRequest request)
    {
        var response = await _userService.CreateUserAsync(request);
        return Ok(response);
    }

    [HttpGet("GetByEmailAddress")]
    public async Task<IActionResult> GetUserByEmailAddressAsync(string emailAddress, string password)
    {
        var response = await _userService.GetUserByEmailAddressAsync(
            new LogInByEmailAddressUserRequest 
            { 
            EmailAddress = emailAddress, Password = password
            });
        return Ok(response);
    }

    [HttpGet("GetByPhoneNumber")]
    public async Task<IActionResult> GetUserByPhoneNumberAsync(string phoneNumber, string password)
    {
        var response = await _userService.GetUserByPhoneNumberAsync(
            new LogInByPhoneNumberUserRequest
            {
                PhoneNumber = phoneNumber, 
                Password = password
            });
        return Ok(response);
    }

    [HttpPut("{userAuthData}, {newPassword}")]
    public async Task<IActionResult> UpdateUserAsync(string userAuthData, string newPassword)
    {
        var result = await _userService.UpdateUserAsync(
            new UpdateUserRequest
            {
                UserAuthData = userAuthData,
                NewPassword = newPassword
            });
        return Ok(result);
    }
}

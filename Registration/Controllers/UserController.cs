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

    [HttpGet]
    public async Task<IActionResult> GetUserByEmailAddressAsync(string emailAddress, string password)
    {
        var response = await _userService.GetUserByEmailAddressAsync(emailAddress, password);
        return Ok(response);
    }

    [HttpGet("Phone")]
    public async Task<IActionResult> GetUserByPhoneNumberAsync(string phoneNumber, string password)
    {
        var response = await _userService.GetUserByPhoneNumberAsync(phoneNumber, password);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAsync(UpdateUserRequest request)
    {
        var result = await _userService.UpdateUserAsync(request);
        return Ok(result);
    }
}

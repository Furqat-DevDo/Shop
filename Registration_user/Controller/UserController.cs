using Microsoft.AspNetCore.Mvc;
using Registration_user.Services.Interfaces;
using Registration_user.UserModel;
using Registration_user.UserModel.Request;
using Registration_user.UserModel.Response;
// For more information on enabling Web API for empty projects, visit z

namespace Registration_user.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userServic)
    {
        _userService = userServic;
    }

    [HttpGet("GetByPhoneNumber,{PhoneNumber},{Password}")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserByPhoneNumberAsync(UserLogInByPhoneNumberRequest numberRequest)
    {
        return Ok(await _userService.GetUserByPhoneNumberAsync(numberRequest));
    }

    [HttpGet("GetByPhoneNumber,{Email},{Password}")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetUserByEmailAsync(UserLogInByEmailRequest emailRequest)
    {
        return Ok(await _userService.GetUserByEmailAsync(emailRequest));
    }

    [HttpPost("you can post here")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest createUserRequest)
    {
        return Ok(await _userService.CreateUserAsync(createUserRequest));
    }

    [HttpPut("you can put here")]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(GetUserResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUserAsync(string password, [FromBody] UpdateUserRequest updateUserRequest)
    {
        var result = await _userService.UpdateUserAsync((string)password, updateUserRequest);
        return Ok(result);  
    }
}

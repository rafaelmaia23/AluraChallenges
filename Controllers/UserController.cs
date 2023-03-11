using AluraChallenges.Models.UserDto;
using AluraChallenges.Services.IService;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenges.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost("/register")]
	public async Task<IActionResult> RegisterUserAsync(CreateUserDto createUserDto)
	{
		Result result = await _userService.RegisterUserAsync(createUserDto);
		if (result.IsFailed) return StatusCode(500);
		return Ok();
    }

	[HttpPost("/login")]
	public async Task<IActionResult> LoginUserAsync(UserLogin userLogin)
	{
		Result result = await _userService.LoginUserAsync(userLogin);
		if(result.IsFailed) return Unauthorized(result.Reasons);
		return Ok(result.Successes.FirstOrDefault());
    }



}

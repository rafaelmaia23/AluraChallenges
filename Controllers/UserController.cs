﻿using AluraChallenges.Models.UserDto;
using AluraChallenges.Services.IService;
using FluentResults;
using Microsoft.AspNetCore.Http;
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



}

using AluraChallenges.Services.IService;
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
}

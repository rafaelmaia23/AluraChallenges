using AluraChallenges.Models;
using AluraChallenges.Models.UserDto;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<Result> LoginUserAsync(UserLogin userLogin)
    {
        var identityResult = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, false);
        if (identityResult.Succeeded)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == userLogin.UserName.ToUpper());
            var roles = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            LoginToken loginToken = _tokenService.GenerateLoginToken(user, roles);
            return Result.Ok().WithSuccess(loginToken.Value);                
        }
        return Result.Fail("Username or password invalid");
    }

    public async Task<Result> RegisterUserAsync(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        var identityResult = await _userManager.CreateAsync(user, createUserDto.Password);
        var roleResult = await _userManager.AddToRoleAsync(user, "client");
        if (identityResult.Succeeded) return Result.Ok();
        return Result.Fail("Fail to register user");
    }

}

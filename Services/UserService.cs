using AluraChallenges.Models;
using AluraChallenges.Models.UserDto;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace AluraChallenges.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
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

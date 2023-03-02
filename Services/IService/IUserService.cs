using AluraChallenges.Models.UserDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface IUserService
{
    Task<Result> LoginUserAsync(UserLogin userLogin);
    Task<Result> RegisterUserAsync(CreateUserDto createUserDto);
}

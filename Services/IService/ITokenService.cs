using AluraChallenges.Models;

namespace AluraChallenges.Services.IService;

public interface ITokenService
{
    LoginToken GenerateLoginToken(User user, string? roles);
}

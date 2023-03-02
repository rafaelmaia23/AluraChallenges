using AluraChallenges.Models;
using AluraChallenges.Services.IService;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AluraChallenges.Services;

public class TokenService : ITokenService
{
    public LoginToken GenerateLoginToken(User user, string? roles)
    {
        Claim[] userClaims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Role, roles)
        };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            "ch4v3Al3a70R!aQ&d3v&s&rsecr#ta")
        );
        
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            claims: userClaims,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddHours(1)
        );

        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new LoginToken(tokenString);
    }
}

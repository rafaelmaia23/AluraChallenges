using AluraChallenges.Models;
using AluraChallenges.Models.UserDto;
using AutoMapper;

namespace AluraChallenges.Profiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<CreateUserDto, User>();
	}
}

using AluraChallenges.Models;
using AluraChallenges.Models.VideoDto;
using AutoMapper;

namespace AluraChallenges.Profiles;

public class VideoProfile : Profile
{
	public VideoProfile()
	{
		CreateMap<CreateVideoDto, Video>();
		CreateMap<Video, ReadVideoDto>();
		CreateMap<UpdateVideoDto, Video>();
	}
}

using AluraChallenges.Data;
using AluraChallenges.Models;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;

namespace AluraChallenges.Services;

public class VideoService : IVideoService
{
    private readonly AppDbContext _db;
    private readonly IMapper mapper
    public VideoService()
    {

    }
    public Task<Result<List<Video>>> GetVideosAsync()
    {
        throw new NotImplementedException();
    }
}

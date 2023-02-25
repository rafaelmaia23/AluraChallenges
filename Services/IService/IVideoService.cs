using AluraChallenges.Models;
using AluraChallenges.Models.VideoDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface IVideoService
{
    Task<Result<ReadVideoDto>> GetVideoByIdAsync(int id);
    Task<Result<List<ReadVideoDto>>> GetVideosAsync(int skip, int take);
    Task<Result<ReadVideoDto>> PostVideoAsync(CreateVideoDto createVideoDto);
}

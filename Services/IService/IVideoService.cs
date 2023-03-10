using AluraChallenges.Models;
using AluraChallenges.Models.VideoDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface IVideoService
{
    Task<Result> DeleteVideoAsync(int id);
    Task<Result<List<ReadVideoDto>>> GetFreeVideosAsync();
    Task<Result<ReadVideoDto>> GetVideoByIdAsync(int id);
    Task<Result<List<ReadVideoDto>>> GetVideosAsync(int skip, int take, string search);
    Task<Result<ReadVideoDto>> PostVideoAsync(CreateVideoDto createVideoDto);
    Task<Result> PutVideoAsync(int id, UpdateVideoDto updateVideoDto);
}

using AluraChallenges.Data;
using AluraChallenges.Models;
using AluraChallenges.Models.VideoDto;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Services;

public class VideoService : IVideoService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    public VideoService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Result> DeleteVideoAsync(int id)
    {
        Video? video = await _db.videos.FirstOrDefaultAsync(x => x.Id == id);
        if (video == null) return Result.Fail("Not Found");
        _db.videos.Remove(video);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result<ReadVideoDto>> GetVideoByIdAsync(int id)
    {
        Video? video = await _db.videos.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        if (video == null) return Result.Fail("Not Found");
        ReadVideoDto readVideoDto = _mapper.Map<ReadVideoDto>(video);
        return Result.Ok(readVideoDto);
    }

    public async Task<Result<List<ReadVideoDto>>> GetVideosAsync(int skip, int take, string search)
    {
        List<Video>? videos = new List<Video>();
        if (!String.IsNullOrEmpty(search))
        {
            videos = await _db.videos.Where(s => s.Title!.Contains(search))
                .Skip(skip).Take(take).ToListAsync();
        }
        else
        {
            videos = await _db.videos.Skip(skip).Take(take).Include(x => x.Category).ToListAsync();
        }

        if (videos == null || videos.Count == 0) return Result.Fail("Not Found");
        List<ReadVideoDto> readVideoDtos = _mapper.Map<List<ReadVideoDto>>(videos);
        return Result.Ok(readVideoDtos);
    }

    public async Task<Result<ReadVideoDto>> PostVideoAsync(CreateVideoDto createVideoDto)
    {
        if (createVideoDto.CategoryId == 0) createVideoDto.CategoryId = 1;
        if (!_db.categories.Any(x => x.Id == createVideoDto.CategoryId)) return Result.Fail("Bad Request: Category do not exist");
        Video video = _mapper.Map<Video>(createVideoDto);        
        await _db.videos.AddAsync(video);
        await _db.SaveChangesAsync();
        ReadVideoDto readVideoDto = _mapper.Map<ReadVideoDto>(video);
        return Result.Ok(readVideoDto);
    }

    public async Task<Result> PutVideoAsync(int id, UpdateVideoDto updateVideoDto)
    {
        Video? video = await _db.videos.FirstOrDefaultAsync(x => x.Id == id);
        if (video == null) return Result.Fail("Video Not Found");
        _mapper.Map(updateVideoDto, video);
        _db.videos.Update(video);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }
}

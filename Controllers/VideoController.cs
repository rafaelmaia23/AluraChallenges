using AluraChallenges.Models.VideoDto;
using AluraChallenges.Services.IService;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenges.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController : ControllerBase
{
    private readonly IVideoService _videoService;

    public VideoController(IVideoService videoService)
    {
        _videoService = videoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetVideosAsync([FromQuery] int skip = 0, [FromQuery] int take = 20) 
    {
        Result<List<ReadVideoDto>> result = await _videoService.GetVideosAsync(skip, take);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVideoByIdAsync(int id)
    {
        Result<ReadVideoDto> result = await _videoService.GetVideoByIdAsync(id);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }
}

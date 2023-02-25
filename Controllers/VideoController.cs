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
    [ActionName("GetVideoByIdAsync")]
    public async Task<IActionResult> GetVideoByIdAsync(int id)
    {
        Result<ReadVideoDto> result = await _videoService.GetVideoByIdAsync(id);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> PostVideoAsync(CreateVideoDto  createVideoDto)
    {
        Result<ReadVideoDto> result = await _videoService.PostVideoAsync(createVideoDto);
        return CreatedAtAction(nameof(GetVideoByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutVideoAsync(int id, UpdateVideoDto updateVideoDto)
    {
        Result result = await _videoService.PutVideoAsync(id, updateVideoDto);
        if(result.IsFailed) return NotFound();
        return NoContent();
    }
}

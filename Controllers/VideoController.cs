using AluraChallenges.Models.VideoDto;
using AluraChallenges.Services.IService;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "admin, client")]
    public async Task<IActionResult> GetVideosAsync([FromQuery] int skip = 0, [FromQuery] int take = 5, [FromQuery] string search = null) 
    {
        Result<List<ReadVideoDto>> result = await _videoService.GetVideosAsync(skip, take, search);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ActionName("GetVideoByIdAsync")]
    [Authorize(Roles = "admin, client")]
    public async Task<IActionResult> GetVideoByIdAsync(int id)
    {
        Result<ReadVideoDto> result = await _videoService.GetVideoByIdAsync(id);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> PostVideoAsync([FromBody] CreateVideoDto  createVideoDto)
    {
        Result<ReadVideoDto> result = await _videoService.PostVideoAsync(createVideoDto);
        if(result.IsFailed) return BadRequest(result.Reasons);
        return CreatedAtAction(nameof(GetVideoByIdAsync), new { id = result.Value.Id }, result.Value);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> PutVideoAsync(int id, [FromBody] UpdateVideoDto updateVideoDto)
    {
        Result result = await _videoService.PutVideoAsync(id, updateVideoDto);
        if(result.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteVideoAsync(int id)
    {
        Result result = await _videoService.DeleteVideoAsync(id);
        if (result.IsFailed) return NotFound();
        return NoContent();
    }
}

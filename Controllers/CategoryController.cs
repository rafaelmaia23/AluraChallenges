using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AluraChallenges.Models.VideoDto;
using AluraChallenges.Services.IService;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace AluraChallenges.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController  : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        Result<List<ReadCategoryDto>> result = await _categoryService.GetCategoriesAsync(skip, take);
        if (result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    [ActionName("GetCategoryByIdAsync")]
    public async Task<IActionResult> GetCategoryByIdAsync(int id)
    {
        Result<ReadCategoryDto> result = await _categoryService.GetCategoryByIdAsync(id);
        if (result.IsFailed) return NotFound();
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<IActionResult> PostCategoryAsync([FromBody] CreateCategoryDto createCategoryDto)
    {
        Result<ReadCategoryDto> result = await _categoryService.PostCategoryAsync(createCategoryDto);
        return CreatedAtAction(nameof(GetCategoryByIdAsync), new {id = result.Value.Id}, result.Value);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoryAsync(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {
        Result result = await _categoryService.PutCategoryAsync(id, updateCategoryDto);
        if(result.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryAsync(int id)
    {
        Result result = await _categoryService.DeleteCategoryAsync(id);
        if(result.IsFailed) return NotFound();
        return NoContent();
    }

    [HttpGet("{id}/Videos")]
    public async Task<IActionResult> GetVideosByCategory(int id)
    {
        Result<List<ReadVideoDto>> result = await _categoryService.GetVideosByCategory(id);
        if(result.IsFailed) return NotFound();
        return Ok(result.Value);
    }
}

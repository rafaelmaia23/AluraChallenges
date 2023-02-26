using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
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
    public async Task<IActionResult> GetCategoriesAsync([FromQuery] int skip = 0, [FromQuery] int take = 20)
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
    public async Task<IActionResult> PostCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        Result<ReadCategoryDto> result = await _categoryService.PostCategoryAsync(createCategoryDto);
        return CreatedAtAction(nameof(GetCategoryByIdAsync), new {id = result.Value.Id}, result.Value);
    }


}

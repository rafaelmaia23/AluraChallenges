using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AluraChallenges.Models.VideoDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface ICategoryService
{
    Task<Result> DeleteCategoryAsync(int id);
    Task<Result<List<ReadCategoryDto>>> GetCategoriesAsync(int skip, int take);
    Task<Result<ReadCategoryDto>> GetCategoryByIdAsync(int id);
    Task<Result<List<ReadVideoDto>>> GetVideosByCategory(int id);
    Task<Result<ReadCategoryDto>> PostCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<Result> PutCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
}

using AluraChallenges.Data;
using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _db;
    private readonly IMapper _mapper;
    public CategoryService(AppDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Result<List<ReadCategoryDto>>> GetCategoriesAsync(int skip, int take)
    {
        List<Category> categories = await _db.categories.ToListAsync();
        if (categories == null) return Result.Fail("Not Found");
        List<ReadCategoryDto> readCategoryDtos = _mapper.Map<List<ReadCategoryDto>>(categories);
        return Result.Ok(readCategoryDtos);
    }
}

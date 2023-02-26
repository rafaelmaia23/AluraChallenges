using AluraChallenges.Data;
using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AluraChallenges.Services.IService;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;
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
        List<Category> categories = await _db.categories.Skip(skip).Take(take).ToListAsync();
        if (categories == null) return Result.Fail("Not Found");
        List<ReadCategoryDto> readCategoryDtos = _mapper.Map<List<ReadCategoryDto>>(categories);
        return Result.Ok(readCategoryDtos);
    }

    public async Task<Result<ReadCategoryDto>> GetCategoryByIdAsync(int id)
    {
        Category? category = await _db.categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) return Result.Fail("Not Found");
        ReadCategoryDto readCategoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Result.Ok(readCategoryDto);
    }

    public async Task<Result<ReadCategoryDto>> PostCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        Category category = _mapper.Map<Category>(createCategoryDto);
        await _db.categories.AddAsync(category);
        await _db.SaveChangesAsync();
        ReadCategoryDto readCategoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Result.Ok(readCategoryDto);
    }
}

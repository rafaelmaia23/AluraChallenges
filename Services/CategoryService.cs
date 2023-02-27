using AluraChallenges.Data;
using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AluraChallenges.Models.VideoDto;
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

    public async Task<Result> DeleteCategoryAsync(int id)
    {
        Category? category = await _db.categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) return Result.Fail("Not found");
        _db.categories.Remove(category);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result<List<ReadCategoryDto>>> GetCategoriesAsync(int skip, int take)
    {
        List<Category> categories = await _db.categories.Skip(skip).Take(take).ToListAsync();
        if (categories == null || categories.Count == 0) return Result.Fail("Not Found");
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

    public async Task<Result<List<ReadVideoDto>>> GetVideosByCategory(int id)
    {
        Category? category = await _db.categories.Include(x => x.Videos).FirstOrDefaultAsync(x => x.Id == id);
        if (category == null || category.Videos.Count == 0 || category.Videos == null) return Result.Fail("Not Found");
        List<ReadVideoDto> readVideoDtos = _mapper.Map<List<ReadVideoDto>>(category.Videos);
        return Result.Ok(readVideoDtos);
    }

    public async Task<Result<ReadCategoryDto>> PostCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        Category category = _mapper.Map<Category>(createCategoryDto);
        await _db.categories.AddAsync(category);
        await _db.SaveChangesAsync();
        ReadCategoryDto readCategoryDto = _mapper.Map<ReadCategoryDto>(category);
        return Result.Ok(readCategoryDto);
    }

    public async Task<Result> PutCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
    {
        Category? category = await _db.categories.FirstOrDefaultAsync(x => x.Id == id);
        if (category == null) return Result.Fail("Not Found");
        _mapper.Map(updateCategoryDto, category);
        _db.categories.Update(category);
        await _db.SaveChangesAsync();
        return Result.Ok();
    }
}

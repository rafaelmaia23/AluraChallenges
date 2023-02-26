﻿using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface ICategoryService
{
    Task<Result<List<ReadCategoryDto>>> GetCategoriesAsync(int skip, int take);
    Task<Result<ReadCategoryDto>> GetCategoryByIdAsync(int id);
}

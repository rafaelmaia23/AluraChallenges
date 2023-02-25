﻿using AluraChallenges.Models.CategoryDto;
using FluentResults;

namespace AluraChallenges.Services.IService;

public interface ICategoryService
{
    Task<Result<List<ReadCategoryDto>>> GetCategoriesAsync(int skip, int take);
}

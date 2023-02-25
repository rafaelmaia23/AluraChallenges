using AluraChallenges.Models;
using AluraChallenges.Models.CategoryDto;
using AutoMapper;

namespace AluraChallenges.Profiles;

public class CategoryProfile : Profile
{
	public CategoryProfile()
	{
		CreateMap<CreateCategoryDto, Category>();
		CreateMap<Category, ReadCategoryDto>();
		CreateMap<UpdateCategoryDto, Category>();
	}
}

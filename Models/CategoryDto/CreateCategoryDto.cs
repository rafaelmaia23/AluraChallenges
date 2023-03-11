using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models.CategoryDto;

public class CreateCategoryDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Color { get; set; }
}

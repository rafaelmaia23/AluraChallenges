using AluraChallenges.Models.VideoDto;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AluraChallenges.Models.CategoryDto;

public class ReadCategoryDto
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Color { get; set; }
}

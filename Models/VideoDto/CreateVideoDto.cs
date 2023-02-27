using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models.VideoDto;

public class CreateVideoDto
{
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Url { get; set; }
}

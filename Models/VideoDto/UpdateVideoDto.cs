using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models.VideoDto;

public class UpdateVideoDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Url { get; set; }
}

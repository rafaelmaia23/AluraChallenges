using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AluraChallenges.Models;

public class Video
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    [Required]
    public Category Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Url { get; set; }

}

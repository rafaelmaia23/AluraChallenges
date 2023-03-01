using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models;

public class User
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Role { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
}

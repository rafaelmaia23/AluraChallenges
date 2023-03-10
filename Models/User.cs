using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AluraChallenges.Models;

public class User : IdentityUser
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
}

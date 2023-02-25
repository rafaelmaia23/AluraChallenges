using AluraChallenges.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
	{

	}

	public DbSet<Video> videos { get; set; }
	public DbSet<Category> categories { get; set; }
}

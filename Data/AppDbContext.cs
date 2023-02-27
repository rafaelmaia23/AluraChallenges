using AluraChallenges.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
	{

	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Video>()
			.HasOne(video => video.Category)
			.WithMany(category => category.Videos)
			.HasForeignKey(video => video.CategoryId);
	}

	public DbSet<Video> videos { get; set; }
	public DbSet<Category> categories { get; set; }
}

using AluraChallenges.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Data;

public class AppDbContext : IdentityDbContext<User>
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

		Category category = new Category
		{
			Id = 1,
			Title = "Livre",
			Color = "branco"
		};
		modelBuilder.Entity<Category>().HasData(category);
	}

	public DbSet<Video> videos { get; set; }
	public DbSet<Category> categories { get; set; }
}

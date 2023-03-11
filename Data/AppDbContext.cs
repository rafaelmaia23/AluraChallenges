using AluraChallenges.Models;
using Microsoft.AspNetCore.Identity;
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
		base.OnModelCreating(modelBuilder);
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

		modelBuilder.Entity<IdentityRole>().HasData(
			new IdentityRole
			{
				Id = "adminrole",
				Name = "admin",
				NormalizedName = "ADMIN"
			}
		);
		modelBuilder.Entity<IdentityRole>().HasData(
			new IdentityRole
			{
				Id = "clientrole",
				Name = "client",
				NormalizedName = "CLIENT"
			}
		);

		User admin = new User
		{
			Name = "admin",
			Surname = "admin",
			UserName = "admin",
			NormalizedUserName = "ADMIN",
			Email = "admin@admin.com",
			NormalizedEmail = "ADMIN@ADMIN.COM",
			EmailConfirmed = true,
			SecurityStamp = Guid.NewGuid().ToString(),
			Id = "admin"
		};
		PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
		admin.PasswordHash = passwordHasher.HashPassword(admin, "password");
		modelBuilder.Entity<User>().HasData(admin);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string>
			{
				RoleId = "adminrole",
				UserId = "admin"
			}
		);
    }

	public DbSet<Video> videos { get; set; }
	public DbSet<Category> categories { get; set; }
}

﻿using Microsoft.EntityFrameworkCore;

namespace AluraChallenges.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
	{

	}
}

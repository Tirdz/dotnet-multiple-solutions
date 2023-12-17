using Hello.World.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hello.World.DataAccess.DataContext;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<SampleEntity> Samples { get; set; }
}


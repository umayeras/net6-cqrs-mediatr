using Microsoft.EntityFrameworkCore;
using WebApp.Data.Constants;
using WebApp.Data.Entities;

namespace WebApp.Data.DbContexts;

public class WritableDbContext : DbContext
{
    public WritableDbContext(DbContextOptions<WritableDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sample>().ToTable(TableName.Samples);
        modelBuilder.Entity<Status>().ToTable(TableName.Status);
    }
}
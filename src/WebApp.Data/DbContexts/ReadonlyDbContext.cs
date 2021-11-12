using Microsoft.EntityFrameworkCore;
using WebApp.Data.Constants;
using WebApp.Data.Entities;

namespace WebApp.Data.DbContexts
{
    public class ReadonlyDbContext : DbContext
    {
        public ReadonlyDbContext(DbContextOptions<ReadonlyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>().ToTable(TableName.Samples);
            modelBuilder.Entity<Status>().ToTable(TableName.Status);
        }
    }
}
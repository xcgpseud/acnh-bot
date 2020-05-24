using ACNHBot.Application.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACNHBot.Application.Database.Contexts
{
    public class SqliteContext : DbContext
    {
        public DbSet<ArtEntity> Arts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=acnhbot.db");
        }
    }
}
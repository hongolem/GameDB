using Microsoft.EntityFrameworkCore;
using GameDB.Models;

namespace GameDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasMany(e => e.Genres)
                    .WithMany(g => g.Games)
                    .UsingEntity<GameGenre>();
                entity.HasData(
                    new Game { GameId = 1, Name = "Minecraft", Developers = "Notch", ReleaseDate = new DateOnly(2001, 1, 1) }
                    );
            });
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Name = "Survival" }
            );
            modelBuilder.Entity<GameGenre>(entity =>
            {
                entity.HasKey(gg => new { gg.GameId, gg.GenreId });
                entity.HasData(new GameGenre { GameId = 1, GenreId = 1 });
            });
        }
    }
}

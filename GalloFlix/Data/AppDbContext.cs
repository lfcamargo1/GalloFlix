using GalloFlix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace GalloFlix.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }

    // FluenteAPI
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        #region Configurando o Muitos para Muitos do MovieGenre
        // Chave primária composta
        builder.Entity<MovieGenre>().HasKey(
            mg => new { mg.MovieId, mg.GenreId }
        );
        // Chave estrangeira do Movie
        builder.Entity<MovieGenre>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.Genres)
            .HasForeignKey(mg => mg.MovieId);
        // Chave estrangeira do Genre
        
        builder.Entity<MovieGenre>()
            .HasOne(mg => mg.Genre)
            .WithMany(m => m.Movies)
            .HasForeignKey(mg => mg.GenreId);
        #endregion
    }
}

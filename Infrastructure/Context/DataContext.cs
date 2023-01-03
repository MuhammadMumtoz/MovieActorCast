using Microsoft.EntityFrameworkCore;
using Domain.Entities;
namespace Infrastructure.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cast> Casts { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cast>()
        .HasKey(bc => new { bc.MovieId, bc.ActorId });

        modelBuilder.Entity<Cast>()
        .HasOne(bc => bc.Movie)
        .WithMany(b => b.Casts)
        .HasForeignKey(bc => bc.MovieId);

        modelBuilder.Entity<Cast>()
        .HasOne(bc => bc.Actor)
        .WithMany(c => c.Casts)
        .HasForeignKey(bc => bc.ActorId);

        modelBuilder.Entity<Actor>().HasData(
            new Actor
            {
                ActorId = 1,
                Fullname = "Will Smith",
                Gender = Gender.male,
                BirthYear = new DateTime(1968, 9, 25, 7, 0, 0, DateTimeKind.Utc)
            },
            new Actor
            {
                ActorId = 2,
                Fullname = "Jessica Alba",
                Gender = Gender.female,
                BirthYear = new DateTime(1981, 4, 28, 7, 0, 0, DateTimeKind.Utc)
            },
            new Actor
            {
                ActorId = 3,
                Fullname = "Chris Evans",
                Gender = Gender.male,
                BirthYear = new DateTime(1981, 6, 13, 7, 0, 0, DateTimeKind.Utc),
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                CategoryId = 1,
                Title = "Action"
            },
            new Category
            {
                CategoryId = 2,
                Title = "Comedy"
            },
            new Category
            {
                CategoryId = 3,
                Title = "Fantasy"
            }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1,
                Title = "In pursuit of Happiness",
                MovieYear = new DateTime(2006, 12, 15, 7, 0, 0, DateTimeKind.Utc),
                CategoryId = 2
            },
            new Movie
            {
                MovieId = 2,
                Title = "Fantastic Four",
                MovieYear = new DateTime(2005, 7, 8, 7, 0, 0, DateTimeKind.Utc),
                CategoryId = 1
            },
            new Movie
            {
                MovieId = 3,
                Title = "Captain America",
                MovieYear = new DateTime(2015, 7, 19, 7, 0, 0, DateTimeKind.Utc),
                CategoryId = 1
            },
            new Movie
            {
                MovieId = 4,
                Title = "Spy Kids",
                MovieYear = new DateTime(2001, 3, 30, 7, 0, 0, DateTimeKind.Utc),
                CategoryId = 3
            }
        );
        modelBuilder.Entity<Cast>().HasData(
            new Cast
            {
                CastId = 1,
                MovieId = 1,
                ActorId = 1
            },
            new Cast
            {
                CastId = 2,
                MovieId = 2,
                ActorId = 2
            },
            new Cast
            {
                CastId = 3,
                MovieId = 2,
                ActorId = 3
            },
            new Cast
            {
                CastId = 4,
                MovieId = 3,
                ActorId = 3
            },
            new Cast
            {
                CastId = 5,
                MovieId = 4,
                ActorId = 2
            }
        );
    }
}
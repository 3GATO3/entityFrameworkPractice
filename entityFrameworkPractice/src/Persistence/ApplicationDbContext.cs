using entityFrameworkPractice.Entities;
using entityFrameworkPractice.Entities.Seeding;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace entityFrameworkPractice.src.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Genre>().Property(g => g.Name).HasMaxLength(150);
            // modelBuilder.Entity<Actor>().Property(C => C.Name).HasMaxLength(150);

            // modelBuilder.Entity<Movie>().Property(a=> a.Title).HasMaxLength(150);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            InitialSeeding.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<MovieActor> MoviesActors => Set<MovieActor>();
    }
}

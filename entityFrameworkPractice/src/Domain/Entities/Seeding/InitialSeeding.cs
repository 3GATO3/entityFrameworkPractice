using Microsoft.EntityFrameworkCore;

namespace entityFrameworkPractice.Entities.Seeding
{
    public class InitialSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var sL = new Actor()
            {
                Id = 2,
                Name = "Samuel L. Jackson",
                BirthDate = new DateTime(1948, 12, 21),
                Fortune = 15000
            };
            var hC = new Actor()
            {
                Id = 3,
                Name = "Henry Cavill",
                BirthDate = new DateTime(1988, 12, 21),
                Fortune = 15000
            };

            modelBuilder.Entity<Actor>().HasData(sL, hC);
            var jL = new Movie()
            {
                Id = 5,
                Title = "Justice League",
                InTheaters = "true" ,
                Premiere = new DateTime(2022, 10, 7)

            };
            modelBuilder.Entity<Movie>().HasData(jL);

            var commentJL = new Comment()
            {
                Id = 6,
                ItIsRecommended = true,
                Content="blah blah blah",
                MovieId = 5,
            };

            modelBuilder.Entity < Comment> ().HasData(commentJL);
            var genreMovieTable = "GenreMovie";
            var genresIdProperty= "GenresId";
            var moviesIdProperty = "MoviesId";

            modelBuilder.Entity(genreMovieTable).HasData(
                new Dictionary<string, object> { [genresIdProperty] = 5, [moviesIdProperty]= jL.Id});


            var jLHC = new MovieActor { ActorId=3,MovieId=5, Order=1, Character="Super Man"};
            modelBuilder.Entity<MovieActor>().HasData(jLHC);
        }
    }
}

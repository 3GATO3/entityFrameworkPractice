using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.DTOs
{
    public class MovieCreationDTO
    {
        public string Title { get; set; } = null!;
        public string InTheaters { get; set; } = null!;
        public DateTime Premiere { get; set; }
        public List<int> Genres { get; set; } = new List<int>();
        public List<MovieActorCreationDTO> MoviesActors { get; set; }=
            new List<MovieActorCreationDTO>();
    }
}

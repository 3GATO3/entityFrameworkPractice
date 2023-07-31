namespace entityFrameworkPractice.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();

    }
}

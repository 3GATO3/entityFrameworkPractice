namespace entityFrameworkPractice.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool ItIsRecommended { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}

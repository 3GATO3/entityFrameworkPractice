namespace entityFrameworkPractice.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime BirthDate { get; set; }
        public List<MovieActor> MoviesActors { get; set; } = new List<MovieActor>();

 
    }
}

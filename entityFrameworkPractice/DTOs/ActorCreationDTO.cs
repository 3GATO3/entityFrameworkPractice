namespace entityFrameworkPractice.DTOs
{
    public class ActorCreationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Fortune { get; set; }
        public DateTime BirthDate { get; set; }
    }
}

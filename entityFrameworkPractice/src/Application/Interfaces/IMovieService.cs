namespace entityFrameworkPractice.src.Application.Interfaces
{
    public interface IMovieService
    {
        public Task<List<string>> GetMovieIdByName(string movieName);
    }
}

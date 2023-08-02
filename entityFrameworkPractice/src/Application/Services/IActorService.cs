using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Services
{
    public interface IActorService
    {
        IEnumerable<Actor> GetActors();
        Task<IEnumerable<Actor>> GetByDateBirth(int startYear, int endYear);
        Task<Actor> Create(string name, decimal fortune);
    }
}

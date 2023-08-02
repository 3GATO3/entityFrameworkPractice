using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Interfaces
{
    public interface IActorRepository
    {
        List<Actor> GetAllActors(Specification<Actor> specification);
    }
}

using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications.ActorSpec
{
    public class GetActorAndMoviesSpec : Specification<Actor>
    {
        public GetActorAndMoviesSpec(string name)
        {
            Query.Where(x => x.Name.Contains(name)).Include(i => i.MoviesActors)
                .ThenInclude(t => t.Movie);
        }

    }
}

using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications
{
    public class ActorByIdSpec : SingleResultSpecification<Actor>
    {
        public ActorByIdSpec(int Id)
        {
            Query.Where(x => x.Id == Id);
        }
    }
}

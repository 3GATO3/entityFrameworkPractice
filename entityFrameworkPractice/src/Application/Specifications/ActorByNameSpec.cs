using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications
{
    public class ActorByNameSpec : Specification<Actor>
    {
        public ActorByNameSpec(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Query.Where(a => a.Name.Contains(name));
            }

        }
    }
}

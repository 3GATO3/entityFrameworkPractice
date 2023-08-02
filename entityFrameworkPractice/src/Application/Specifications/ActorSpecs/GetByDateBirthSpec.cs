using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications.ActorSpec
{
    public class GetByDateBirthSpec : Specification<Actor>
    {
        public GetByDateBirthSpec(int startYear, int endYear)
        {
            Query.Where(x => (short)x.BirthDate.Date.Year > (short)startYear && x.BirthDate.Date.Year < endYear);
        }
    }
}

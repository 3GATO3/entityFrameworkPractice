using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications
{
    public class GetAllActorsSpec : Specification<Actor, string>
    {


        public GetAllActorsSpec()
        {
        
           
                Query.Select(x=> x.Name);
           

        }





    }
}

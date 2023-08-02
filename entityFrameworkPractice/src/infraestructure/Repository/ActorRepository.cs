using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.Interfaces;

//namespace entityFrameworkPractice.src.infraestructure.Repository
//{
//    public class ActorRepository: IActorRepository
//    {
//        private readonly ApplicationDbContext _dbContext;
//        public ActorRepository(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public List<Actor> GetAllActors(ISpecification<Actor> specification)
//        {
//            var queryResult= SpecificationEvaluator.Default.GetQuery(
//                query: _dbContext.Actors.AsQueryable(),
//                specification: specification);
//            return queryResult.ToList();
//        }

//        public List<Actor> GetAllActors(Specification<Actor> specification)
//        {
//            var queryResult = SpecificationEvaluator.Default.GetQuery(
//                query: _dbContext.Actors.AsQueryable(),
//                specification: specification);
//            return queryResult.ToList();
//        }
//    }
//}

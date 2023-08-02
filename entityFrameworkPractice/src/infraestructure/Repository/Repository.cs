using Ardalis.Specification.EntityFrameworkCore;
using entityFrameworkPractice.src.Persistence;

namespace entityFrameworkPractice.src.infraestructure.Repository
{
    public class Repository<T> : RepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

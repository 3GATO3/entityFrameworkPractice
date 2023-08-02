using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.Services;
using entityFrameworkPractice.src.Application.Specifications;
using entityFrameworkPractice.src.infraestructure;
using entityFrameworkPractice.src.infraestructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkPractice.Services
{
    public class ActorService: IActorService
        //Actor Repository
    {
        private readonly Repository<Actor> actorRepository;
        private readonly ApplicationDbContext context;
        public ActorService (Repository<Actor> actorRepository, ApplicationDbContext context)
        {
            this.actorRepository = actorRepository;
            this.context = context;
        }

        //with repository
        public Task<List<Actor>> GetActorsByName(string name)
        {
            return actorRepository.ListAsync(new ActorByNameSpec(name));
        }

        public Task<List<Actor>> GetActorsById(int  id) { return actorRepository.ListAsync(
            new ActorByIdSpec(id));}

        public Task<List<string>> GetAllActors() 
        { return actorRepository.ListAsync(new GetAllActorsSpec()); }



        public async Task<Actor> GetById(int id)
        {
            return await actorRepository.GetByIdAsync(id);
        }

        public async Task<Actor> Create(string name, decimal fortune)
        {
            var actor = new Actor() { Name=name,Fortune= fortune };

            await actorRepository.AddAsync(actor);

            await actorRepository.SaveChangesAsync();

            return actor;
        }

        public IEnumerable<Actor> GetActors()
        {
            //with context
            return context.Actors.ToList();
            
        }




        //public Task<List<Actor>> GetByDateBirth(int startYear, int endYear)
        //{ return actorRepository.ListAsync(new GetByDateBirthSpec(startYear,endYear)); }


        public async  Task<IEnumerable<Actor>> GetByDateBirth(int startYear, int endYear)
        {
            var result =  await actorRepository.ListAsync(new GetByDateBirthSpec(startYear, endYear));

            return result;
        }
    }
}

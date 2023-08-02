using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkPractice.src.Application.Interfaces
{
    public interface IActorService
    {
        IEnumerable<Actor> GetActors();
        public Task<List<Actor>> GetActorsByName(string name);
        public Task<List<Actor>> GetActorsById(int id);
        public Task<List<string>> GetAllActors();
        public Task<Actor> CreateWithDTO(ActorCreationDTO actorCreationDTO);
        Task<IEnumerable<Actor>> GetByDateBirth(int startYear, int endYear);
        Task<Actor> Create(string name, decimal fortune);
        Task<List<Actor>> GetActorAndMovies(string actorName);

        Task<string> Delete(int id);
        Task<string> Put(int id, ActorCreationDTO actorCreationDTO);
    }
}

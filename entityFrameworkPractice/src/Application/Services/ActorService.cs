﻿using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Application.Interfaces;
using entityFrameworkPractice.src.Application.Specifications;
using entityFrameworkPractice.src.Application.Specifications.ActorSpec;
using entityFrameworkPractice.src.infraestructure.Repository;
using entityFrameworkPractice.src.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkPractice.Services
{
    public class ActorService: IActorService
        //Actor Repository
    {
        private readonly Repository<Actor> actorRepository;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;
        public ActorService(Repository<Actor> actorRepository, ApplicationDbContext context, IMapper mapper)
        {
            this.actorRepository = actorRepository;
            this.context = context;
            _mapper = mapper;
        }

        //with repository
        public Task<List<Actor>> GetActorsByName(string name)
        {
            return actorRepository.ListAsync(new ActorByNameSpec(name));
        }

        public Task<List<Actor>> GetActorsById(int  id) { 

            return actorRepository.ListAsync(new ActorByIdSpec(id));}

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
        public async Task<Actor> CreateWithDTO(ActorCreationDTO actorCreationDTO)
        {
            var actor = _mapper.Map<Actor>(actorCreationDTO);

            if (actorCreationDTO != null)
            {
                await actorRepository.AddAsync(actor);
                await actorRepository.SaveChangesAsync();
            }
            
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

        public async Task<List<Actor>> GetActorAndMovies(string actorName)
        {
            var result = await actorRepository.ListAsync(new GetActorAndMoviesSpec(actorName));
            return result;
        }

        public async Task<string> Delete(int id)
        {
            var actor =  await actorRepository.FirstOrDefaultAsync(new ActorByIdSpec(id)) ;
            if (actor == null)
            {
                return "Not found";
            }
            await actorRepository.DeleteAsync(actor);
            await actorRepository.SaveChangesAsync() ;
            return "eliminado correctamente";
        }

        public async Task<string> Put(int id, ActorCreationDTO actorCreationDTO)
        {
            var actorExistente = await actorRepository.AnyAsync(new ActorByIdSpec(id));
            if (actorExistente == false)
            {
                return "false";
            }
            var actorNuevo= _mapper.Map<Actor>(actorCreationDTO);
            actorNuevo.Id = id;
            await actorRepository.UpdateAsync(actorNuevo);
            await actorRepository.SaveChangesAsync() ;
            return "true";
        }
    }
}

﻿using Ardalis.Specification.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Application.Interfaces;
using entityFrameworkPractice.src.Application.Specifications;
using entityFrameworkPractice.src.Application.Specifications.ActorSpec;
using entityFrameworkPractice.src.infraestructure.Repository;
using entityFrameworkPractice.src.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entityFrameworkPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly Repository<Actor> actorRepository;
        // private readonly ILogger _logger;
        private readonly IActorService _actorService;
        public ActorsController(ApplicationDbContext context, IMapper mapper, Repository<Actor> actorRepository, IActorService actorService)
        {
            this.context = context;
            this.mapper = mapper;
            // _logger = logger;
            this.actorRepository = actorRepository;
            _actorService = actorService;
        }

        //[HttpPost]
        //public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        //{
        //    var actor = mapper.Map<Actor>(actorCreationDTO);
        //    context.Add(actor);
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpPost("PostDTO")]
        public async Task<ActionResult> PostWithDTO(ActorCreationDTO actorCreationDTO)
        {
            var result = await _actorService.CreateWithDTO(actorCreationDTO);
            return Ok(result);
            
        }

        [HttpPost("PostNombreyFortuna")]
        public async Task<Actor> PostNombreyFortuna(string name, decimal fortune)
        {

            return await _actorService.Create(name, fortune);
        }


        //ardalis}
        [HttpGet("GetAllArdalis/name")]
        public async Task<ActionResult> GetByNameArdalis(string name)
        {
            var result = await _actorService.GetActorsByName(name);
            //var result = await actorRepository.ListAsync(new ActorByNameSpec(name));
            //var result = await context.Actors.ToListAsync(new ActorByNameSpec(name));
            return Ok(result);
        }
        [HttpGet("ardalis/{id:int}")]
        public async Task<ActionResult> GetByIdArdalis(int id)
        {
            var result= await _actorService.GetActorsById(id);
            //var result = await actorRepository.ListAsync(new ActorByIdSpec(id));
            return Ok(result);
        }

        //repository and ardalis
        [HttpGet("GetAlll")]
        public async Task<ActionResult> GetAllActors()
        {
            var result= await _actorService.GetAllActors();
            //var result = await actorRepository.ListAsync(new GetAllActorsSpec());
            return Ok(result);
        }

        //repository
        //[HttpGet("GetAllReopository")]
        //public IEnumerable<Actor> GetAllv()
        //{
        //    return _actorService.GetActors();
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Actor>>> Get()
        //{
        //    return await context.Actors.OrderByDescending(a => a.BirthDate).ToListAsync();
        //}

        //[HttpGet("name")]
        //public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        //{
        //    return await context.Actors.Where(a => a.Name == name).OrderBy(a => a.Name).ThenByDescending(a=> a.BirthDate).ToListAsync();
        //}

        //[HttpGet("name/v2")]
        //public async Task<ActionResult<IEnumerable<Actor>>> Getv2(string name)
        //{
        //    return await context.Actors.Where(a => a.Name.Contains(name)).ToListAsync();
        //}


        [HttpGet("/GetByDateBirth")]
        public async Task<IEnumerable<Actor>> GetByDateBirth(int startYear, int endYear)
        {
            //var result = await actorRepository.ListAsync(new GetByDateBirthSpec(startYear,endYear));
            var result = _actorService.GetByDateBirth(startYear, endYear);
            return await result;

        }

        //[Route("/GetDate")]
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Actor>>> GetDate(DateTime start, DateTime end)
        //{
        //    return await context.Actors.Where(
        //        a => a.BirthDate>= start && a.BirthDate<= end).ToListAsync();
        //}



        //[HttpGet("{id:int}")]
        ////[Route("/GetById/Id")]
        //public async Task<ActionResult<Actor>> Get(int id)
        //{
        //    var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);
        //    return actor == null ? NotFound() : actor;
        //}

        //[HttpGet("IdAndName")]
        //public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdAndName()
        //{
        //    return await context.Actors
        //        .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
        //        .ToListAsync();
        //}

        [HttpGet("GetActorAndMovies")]
        public async Task<List<Actor>> GetActorsAndMovies(string name)
        {
            return await _actorService.GetActorAndMovies(name);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            
            var result = await _actorService.Delete(id);
            if (result == "Not found") {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Modify(int id, ActorCreationDTO actor)
        {
            
           var result = await _actorService.Put(id, actor);
            if (result  == "false")
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}


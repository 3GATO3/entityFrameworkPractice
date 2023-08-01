using AutoMapper;
using AutoMapper.QueryableExtensions;
using entityFrameworkPractice.DTOs;
using entityFrameworkPractice.Entities;
using Microsoft.AspNetCore.Http;
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

        public ActorsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ActorCreationDTO actorCreationDTO)
        {
            var actor = mapper.Map<Actor>(actorCreationDTO);
            context.Add(actor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> Get()
        {
            return await context.Actors.OrderByDescending(a => a.BirthDate ).ToListAsync();
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        {
            return await context.Actors.Where(a => a.Name == name).OrderBy(a => a.Name).ThenByDescending(a=> a.BirthDate).ToListAsync();
        }

        [HttpGet("name/v2")]
        public async Task<ActionResult<IEnumerable<Actor>>> Getv2(string name)
        {
            return await context.Actors.Where(a => a.Name.Contains(name)).ToListAsync();
        }

        [Route("/GetDate")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetDate(DateTime start, DateTime end)
        {
            return await context.Actors.Where(
                a => a.BirthDate>= start && a.BirthDate<= end).ToListAsync();
        }

        [HttpGet("{id:int}")]
        //[Route("/GetById/Id")]
        public async Task<ActionResult<Actor>> Get(int id)
        {
            var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return actor == null ? NotFound() : actor;
        }

        [HttpGet("IdAndName")]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdAndName() 
        {
            return await context.Actors
                .ProjectTo<ActorDTO>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

    }
}


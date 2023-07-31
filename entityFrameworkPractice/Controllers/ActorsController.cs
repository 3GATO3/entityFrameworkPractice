using AutoMapper;
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
            return await context.Actors.ToListAsync();
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
        {
            return await context.Actors.Where(a => a.Name == name).ToListAsync();
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
    }
}


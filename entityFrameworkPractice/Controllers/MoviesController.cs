using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Domain.Entities;
using entityFrameworkPractice.src.infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entityFrameworkPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);
            if (movie.Genres is not null)
            {
                foreach (var genre in movie.Genres)
                {
                    context.Entry(genre).State = EntityState.Unchanged;

                }

            }
            if (movie.MoviesActors is not null) {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }
            context.Add(movie);
            await context.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpGet("{id:int}")] 
        public async Task<ActionResult> Get(int id)
        {
            var movie = await context.Movies.Include(p => p.Comments)
                .Include(p => p.Genres)
                .Include(p=> p.MoviesActors.OrderBy(pa => pa.Order))
                .ThenInclude(pa => pa.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }

            return Ok(movie);
        }


        [HttpGet("select/{id:int}")]

        public async Task<ActionResult> GetSelect(int id)
        {
            var movie = await context.Movies
                .Select( mov => new
                {
                    mov.Id,
                    mov.Title,
                    Genres = mov.Genres.Select(g => g.Name).ToList(),
                    Actors= mov.MoviesActors.OrderBy(mo => mo.Order).Select(ma=>
                    new
                    {
                        id=ma.ActorId,
                        ma.Actor.Name,
                        ma.Character
                    }),
                    CountComments= mov.Comments.Count()
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return BadRequest();
            }

            return Ok(movie);
        }



        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult> Delete(int id)
        {
            var alteredRows = await context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();
            if (alteredRows == 0)
            {
                return NotFound();

            }
            return NoContent();
        }

    }
}

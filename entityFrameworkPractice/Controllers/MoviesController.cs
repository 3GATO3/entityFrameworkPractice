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
        public async Task<ActionResult>Post(MovieCreationDTO movieCreationDTO)
        {
            var movie = mapper.Map<Movie>(movieCreationDTO);
            if ( movie.Genres is not null)
            {
                foreach(var genre in movie.Genres)
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
    }
}

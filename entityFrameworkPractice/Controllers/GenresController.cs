using AutoMapper;
using entityFrameworkPractice.DTOs;
using entityFrameworkPractice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace entityFrameworkPractice.Controllers
{

    [ApiController]
    [Route("api/generos")]
    public class GenresController:ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GenresController(ApplicationDbContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post(GenreCreationDTO genreCreation)
        {
            var genre = _mapper.Map<Genre>(genreCreation);
            _context.Add(genre);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("varios")]
        public async Task<ActionResult> Post(GenreCreationDTO[] genreCreationsDTO)
        {
            var genres = _mapper.Map<Genre[]>(genreCreationsDTO);
            _context.AddRange(genres);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>>Get()
        {
            return await _context.Genres.ToListAsync();
        }
    }
}

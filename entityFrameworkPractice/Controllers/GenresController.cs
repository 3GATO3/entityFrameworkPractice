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
            var alreadyExist= await _context.Genres.AnyAsync( g => g.Name==genreCreation.Name);
            if (alreadyExist)
            {
                return BadRequest("ya existe un genero con ese nombre");
            }
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

        [HttpPut("{id:int}/nombre2")]
        public async Task<ActionResult> Put(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
            if (genre == null)
            {
                return BadRequest();
            }

            genre.Name = genre.Name + "2";
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GenreCreationDTO genreCreationDTO)
        {
            var genre= _mapper.Map<Genre>(genreCreationDTO);
            genre.Id = id;
            _context.Update(genre);
            await _context.SaveChangesAsync();
            return Ok ();
        }


        [HttpDelete("{id:int}/moderna")]
        public async Task<ActionResult>Delete(int id)
        {
            var alteredRows= await _context.Genres.Where(g => g.Id == id).ExecuteDeleteAsync();
            if (alteredRows==0)
            {
                return NotFound();

            }
            return NoContent();
        }



        [HttpDelete("{id:int}/vieja")]
        public async Task<ActionResult> DeleteOld(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Id==id);
            if (genre == null)
            {
                return NotFound();
            }
            _context.Remove(genre);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Domain.Entities;
using entityFrameworkPractice.src.infraestructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkPractice.Controllers
{
    [Route("api/movies/{movieId:int}/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentsController(ApplicationDbContext context, IMapper mapper)
        {
                this._context = context;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post (int movieId, CommentCreationDTO commentCreationDTO)
        {
            var comment = _mapper.Map<Comment>(commentCreationDTO);
            comment.MovieId = movieId;
            await _context.SaveChangesAsync();
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

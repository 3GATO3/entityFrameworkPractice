using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Application.Interfaces;
using entityFrameworkPractice.src.Domain.Entities;
using entityFrameworkPractice.src.infraestructure.Repository;
using entityFrameworkPractice.src.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityFrameworkPractice.Controllers
{
    [Route("api/movies/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        public CommentsController(ApplicationDbContext context, IMapper mapper, ICommentService commentService)
        {
                this._context = context;
            this._mapper = mapper;
            this._commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult> Post (int movieId, CommentCreationDTO commentCreationDTO)
        {
            
            await _commentService.PostComment(movieId, commentCreationDTO);
            return Ok("Comentario publicado");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCommentsOfAMovie(int id)
        {
            var result = await _commentService.GetAllCommentsOfAMovie(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}

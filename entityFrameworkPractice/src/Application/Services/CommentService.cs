using AutoMapper;
using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;
using entityFrameworkPractice.src.Application.Interfaces;
using entityFrameworkPractice.src.Application.Specifications.CommentSpec;
using entityFrameworkPractice.src.infraestructure.Repository;
using entityFrameworkPractice.src.Persistence;

namespace entityFrameworkPractice.src.Application.Services
{
    public class CommentService:ICommentService
    {
        private readonly Repository<Comment> commentRepository;
        private readonly ApplicationDbContext context;
        private readonly IMapper _mapper;
        public CommentService(ApplicationDbContext context, Repository<Comment> commentRepository, IMapper mapper)
        {
            this.context = context;
            this.commentRepository = commentRepository;
            _mapper = mapper;
        }



        public  async Task<Comment> PostComment(int movieId, CommentCreationDTO commentCreationDTO)
        {
            var comment = _mapper.Map<Comment>(commentCreationDTO);
            comment.MovieId = movieId;
            await commentRepository.AddAsync(comment);
            await commentRepository.SaveChangesAsync();
           
            return comment;
        }
        public Task<List<Comment>> GetAllCommentsOfAMovie(int id)
        {

            return commentRepository.ListAsync(new GetAllCommentsOfAMovieSpec (id));

        }
    }
}

using entityFrameworkPractice.Entities;
using entityFrameworkPractice.src.Application.DTOs;

namespace entityFrameworkPractice.src.Application.Interfaces
{
    public interface ICommentService
    {
        public Task<Comment> PostComment(int movieId, CommentCreationDTO commentCreationDTO);
        public Task<List<Comment>> GetAllCommentsOfAMovie(int id);
    }
}

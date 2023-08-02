using Ardalis.Specification;
using entityFrameworkPractice.Entities;

namespace entityFrameworkPractice.src.Application.Specifications.CommentSpec
{
    public class GetAllCommentsOfAMovieSpec : Specification<Comment>
    {
        public GetAllCommentsOfAMovieSpec(int movieId)
        {
            Query.Where(x => x.MovieId == movieId);
        }
    }
}

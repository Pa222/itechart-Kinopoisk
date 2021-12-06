using KinopoiskAPI.Dto.Comment;
using KinopoiskAPI.Dto.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<MoviePage> GetPage(MoviePage info);

        public Task<MovieInfo> Get(int id);

        public Task<List<MovieInfo>> GetMoviesByTitle(string title);

        public Task<List<CommentInfo>> AddComment(AddComment info, int userId);

        public Task<List<CommentInfo>> DeleteComment(DeleteComment info);
    }
}
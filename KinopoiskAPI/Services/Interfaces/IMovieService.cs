using KinopoiskAPI.Dto;
using KinopoiskAPI.Dto.Comment;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinopoiskAPI.Dto.Movie;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<MoviePageDto> GetPage(MoviePageDto info);

        public Task<MovieInfoDto> Get(int id);

        public Task<List<MovieInfoDto>> GetMoviesByTitle(string title);

        public Task<List<CommentInfoDto>> AddComment(AddCommentDto info, int userId);

        public Task<List<CommentInfoDto>> DeleteComment(DeleteCommentDto info);
    }
}
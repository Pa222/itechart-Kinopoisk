using AutoMapper;
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Dto.Comment;
using KinopoiskAPI.Dto.Movie;
using KinopoiskAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class MovieService : GenericService, IMovieService
    {
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<MoviePageDto> GetPage(MoviePageDto info)
        {
            var result = await _unitOfWork.Movies.GetPageAsync(info.PageNumber, info.PageSize);

            info.Movies = _mapper.Map<List<Movie>, List<MovieInfoDto>>(result);
            info.TotalPages = (int)Math.Ceiling(_unitOfWork.Movies.GetAmountOfMovies() / info.PageSize);

            return info;
        }

        public async Task<MovieInfoDto> Get(int id)
        {
            var movie = await _unitOfWork.Movies.GetAsync(id);
            if (movie == null)
            {
                return null;
            }
            var result = new MovieInfoDto();
            _mapper.Map(movie, result);
            result.GenreMovies = movie.GenreMovies.Select(t => t.Genre.Name).ToList();
            result.Comments = _mapper.Map<List<Comment>, List<CommentInfoDto>>(movie.Comments);
            return result;
        }

        public async Task<List<MovieInfoDto>> GetMoviesByTitle(string title)
        {
            var result = await _unitOfWork.Movies.GetMoviesByTitle(title);
            var movies = _mapper.Map<List<Movie>, List<MovieInfoDto>>(result);
            return movies;
        }

        public async Task<List<CommentInfoDto>> AddComment(AddCommentDto info, int userId)
        {
            await _unitOfWork.Comments.Create(new Comment
            {
                Description = info.Description,
                UserId = userId,
                MovieId = info.MovieId,
            });
            var comments = await _unitOfWork.Comments.GetAllByMovie(info.MovieId);
            var mappedComments = _mapper.Map<List<Comment>, List<CommentInfoDto>>(comments);
            return mappedComments;
        }

        public async Task<List<CommentInfoDto>> DeleteComment(DeleteCommentDto info)
        {
            var comment = await _unitOfWork.Comments.Get(info.Id);
            await _unitOfWork.Comments.Delete(comment);
            var comments = await _unitOfWork.Comments.GetAllByMovie(info.MovieId);
            var mappedComments = _mapper.Map<List<Comment>, List<CommentInfoDto>>(comments);
            return mappedComments;
        }
    }
}
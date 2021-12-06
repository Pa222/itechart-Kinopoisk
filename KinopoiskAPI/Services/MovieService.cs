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

        public async Task<MoviePage> GetPage(MoviePage info)
        {
            var result = await UnitOfWork.Movies.GetPageAsync(info.PageNumber, info.PageSize);

            info.Movies = _mapper.Map<List<Movie>, List<MovieInfo>>(result);
            info.TotalPages = (int)Math.Ceiling(UnitOfWork.Movies.GetAmountOfMovies() / info.PageSize);

            return info;
        }

        public async Task<MovieInfo> Get(int id)
        {
            var movie = await UnitOfWork.Movies.GetAsync(id);
            if (movie == null)
            {
                return null;
            }
            var result = new MovieInfo();
            _mapper.Map(movie, result);
            result.GenreMovies = movie.GenreMovies.Select(t => t.Genre.Name).ToList();
            result.Comments = _mapper.Map<List<Comment>, List<CommentInfo>>(movie.Comments);
            return result;
        }

        public async Task<List<MovieInfo>> GetMoviesByTitle(string title)
        {
            var result = await UnitOfWork.Movies.GetMoviesByTitle(title);
            var movies = _mapper.Map<List<Movie>, List<MovieInfo>>(result);
            return movies;
        }

        public async Task<List<CommentInfo>> AddComment(AddComment info, int userId)
        {
            await UnitOfWork.Comments.Create(new Comment
            {
                Description = info.Description,
                UserId = userId,
                MovieId = info.MovieId,
            });
            var comments = await UnitOfWork.Comments.GetAllByMovie(info.MovieId);
            var mappedComments = _mapper.Map<List<Comment>, List<CommentInfo>>(comments);
            return mappedComments;
        }

        public async Task<List<CommentInfo>> DeleteComment(DeleteComment info)
        {
            var comment = await UnitOfWork.Comments.Get(info.Id);
            await UnitOfWork.Comments.Delete(comment);
            var comments = await UnitOfWork.Comments.GetAllByMovie(info.MovieId);
            var mappedComments = _mapper.Map<List<Comment>, List<CommentInfo>>(comments);
            return mappedComments;
        }
    }
}
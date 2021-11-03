using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Services.Interfaces;

namespace KinopoiskAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MovieInfoDto>> GetAll()
        {
            var result = (List<Movie>)await _unitOfWork.Movies.GetAllAsync();
            var movies = new List<MovieInfoDto>();
            _mapper.Map(result, movies);
            for (var i = 0; i < result.Count; i++)
            {
                movies[i].GenreMovies = result[i].GenreMovies.Select(t => t.Genre.Name).ToList();
            }

            return movies;
        }

        public async Task<MovieInfoDto> Get(int id)
        {
            var result = await _unitOfWork.Movies.GetAsync(id);
            var movies = new MovieInfoDto();
            _mapper.Map(result, movies);
            movies.GenreMovies = result.GenreMovies.Select(t => t.Genre.Name).ToList();
            return movies;
        }
    }
}
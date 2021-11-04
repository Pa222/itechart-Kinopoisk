using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private List<MovieInfoDto> FillMovies(List<Movie> input)
        {
            var movies = new List<MovieInfoDto>();
            _mapper.Map(input, movies);
            for (var i = 0; i < input.Count; i++)
            {
                movies[i].GenreMovies = input[i].GenreMovies.Select(t => t.Genre.Name).ToList();
            }
            return movies;
        }

        public async Task<MoviePageDto> GetPage(int pageNumber)
        {
            var dto = new MoviePageDto();

            var result = await _unitOfWork.Movies.GetPageAsync(pageNumber, MoviePageDto.PageSize);

            dto.Movies = FillMovies(result);
            dto.PageNumber = pageNumber;
            dto.TotalPages = (int)Math.Ceiling(_unitOfWork.Movies.GetAmountOfMovies() / MoviePageDto.PageSize);

            return dto;
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
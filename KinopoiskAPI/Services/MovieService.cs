using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using KinopoiskAPI.Services.Interfaces;

namespace KinopoiskAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<ICollection<Movie>> GetAll()
        {
            return _unitOfWork.Movies.GetAll();
        }

        public Task<Movie> Get(int id)
        {
            return _unitOfWork.Movies.Get(id);
        }
    }
}
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public Task<List<Movie>> GetAllAsync();

        public Task<List<Movie>> GetPageAsync(int pageNumber, int pageSize);

        public Task<Movie> GetAsync(int id);

        public decimal GetAmountOfMovies();

        public Task<List<Movie>> GetMoviesByTitle(string title);
    }
}
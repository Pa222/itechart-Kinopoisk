using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Model;

namespace Data_Access_Layer.Interfaces
{
    public interface IMovieRepository : IRepository<Movie>
    {
        public Task<List<Movie>> GetAllAsync();

        public Task<List<Movie>> GetPageAsync(int pageNumber, int pageSize);

        public Task<Movie> GetAsync(int id);

        /////////////////////
        public decimal GetAmountOfMovies();

        /////////////////////
    }
}
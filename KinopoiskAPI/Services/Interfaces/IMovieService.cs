using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Model;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<ICollection<Movie>> GetAll();

        public Task<Movie> Get(int id);
    }
}
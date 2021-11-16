using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        public Task<Rating> GetByMovieAndUser(int movieId, int userId);
    }
}
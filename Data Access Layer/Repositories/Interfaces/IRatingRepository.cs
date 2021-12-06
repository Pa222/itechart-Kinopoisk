using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IRatingRepository : IRepository<Rating>
    {
        public Task<Rating> GetByMovieAndUser(int movieId, int userId);
    }
}
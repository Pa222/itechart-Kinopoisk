using Data_Access_Layer.Entity;
using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class RatingRepository : GenericRepository<Rating>, IRatingRepository
    {
        public RatingRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<Rating> GetByMovieAndUser(int movieId, int userId)
        {
            return await Db.Ratings
                .Where(r => r.MovieId == movieId && r.UserId == userId)
                .FirstOrDefaultAsync(); ;
        }
    }
}
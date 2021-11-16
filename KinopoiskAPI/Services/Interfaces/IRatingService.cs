using System.Threading.Tasks;
using Data_Access_Layer.Entity;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<Rating> GetRating(int movieId, int userId);

        public Task<Rating> CreateRating(Rating rating);

        public Task<Rating> UpdateRating(Rating rating);
    }
}
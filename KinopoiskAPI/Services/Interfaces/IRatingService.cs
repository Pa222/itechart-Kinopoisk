using Data_Access_Layer.Entity;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<Rating> GetRating(int movieId, int userId);

        public Task<Rating> CreateRating(Rating rating);

        public Task<Rating> UpdateRating(Rating rating);
    }
}
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Services.Interfaces;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class RatingService : GenericService, IRatingService
    {
        public RatingService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Rating> GetRating(int movieId, int userId)
        {
            return await _unitOfWork.Ratings.GetByMovieAndUser(movieId, userId);
        }

        public async Task<Rating> CreateRating(Rating rating)
        {
            return await _unitOfWork.Ratings.Create(rating);
        }

        public async Task<Rating> UpdateRating(Rating rating)
        {
            return await _unitOfWork.Ratings.Update(rating);
        }
    }
}
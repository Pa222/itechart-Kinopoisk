using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;

namespace KinopoiskAPI.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICloudinaryApi _cloudinaryApi;

        public ProfileService(IUnitOfWork unitOfWork, ICloudinaryApi cloudinaryApi)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryApi = cloudinaryApi;
        }

        public async Task<bool> AddCreditCard(AddCreditCardDto info, int userId)
        {
            var image = await _cloudinaryApi.GetFileUrl(info.Issuer);
            return await _unitOfWork.CreditCards.Create(new CreditCard
            {
                Number = info.Number,
                CardHolder = info.CardHolder,
                Expiration = info.Expiration,
                Cvv = info.Cvv,
                UserId = userId,
                Image = image,
            });
        }
    }
}
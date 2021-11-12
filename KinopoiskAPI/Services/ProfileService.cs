using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProfileService(IUnitOfWork unitOfWork, ICloudinaryApi cloudinaryApi, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _cloudinaryApi = cloudinaryApi;
            _mapper = mapper;
        }

        public async Task<CreditCardInfoDto> AddCreditCard(AddCreditCardDto info, int userId)
        {
            var card = await _unitOfWork.CreditCards.GetByNumber(info.Number);
            if (card == null)
            {
                await _unitOfWork.CreditCards.Create(new CreditCard
                {
                    Number = info.Number,
                    CardHolderName = info.CardHolderName,
                    Expiry = info.Expiry,
                    Cvc = info.Cvc,
                    UserId = userId,
                    Image = await _cloudinaryApi.GetFileUrl(info.Issuer),
                });
            }

            card = await _unitOfWork.CreditCards.GetByNumber(info.Number);
            var result = new CreditCardInfoDto();
            _mapper.Map(card, result);

            return result;
        }
    }
}
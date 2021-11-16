using AutoMapper;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;

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

        public async Task<List<CreditCardInfoDto>> AddCreditCard(AddCreditCardDto info, int userId)
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

            var cards = await _unitOfWork.CreditCards.GetAllByUserId(userId);
            var result = new List<CreditCardInfoDto>();
            _mapper.Map(cards, result);

            return result;
        }

        public async Task<List<CreditCardInfoDto>> DeleteCreditCard(DeleteCreditCardDto info, int userId)
        {
            var card = await _unitOfWork.CreditCards.GetByNumber(info.Number);
            await _unitOfWork.CreditCards.Delete(card);
            var result = new List<CreditCardInfoDto>();
            var cards = await _unitOfWork.CreditCards.GetAllByUserId(userId);
            _mapper.Map(cards, result);
            return result;
        }

        public async Task<UserInfoDto> UpdateUserProfile(User user, UserUpdateProfileDto info)
        {
            _mapper.Map(info, user);
            await _unitOfWork.Users.Update(user);
            var result = new UserInfoDto
            {
                CreditCards = new List<CreditCardInfoDto>()
            };

            _mapper.Map(user, result);
            _mapper.Map(user.Cards, result.CreditCards);
            return result;
        }
    }
}
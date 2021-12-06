using AutoMapper;
using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.CloudinaryApi;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class ProfileService : GenericService, IProfileService
    {
        private readonly ICloudinaryApi _cloudinaryApi;
        private readonly IMapper _mapper;

        public ProfileService(IUnitOfWork unitOfWork, ICloudinaryApi cloudinaryApi, IMapper mapper) : base(unitOfWork)
        {
            _cloudinaryApi = cloudinaryApi;
            _mapper = mapper;
        }

        public async Task<List<CreditCardInfo>> AddCreditCard(AddCreditCard info, int userId)
        {
            var card = await UnitOfWork.CreditCards.GetByNumber(info.Number);
            if (card == null)
            {
                await UnitOfWork.CreditCards.Create(new CreditCard
                {
                    Number = info.Number,
                    CardHolderName = info.CardHolderName,
                    Expiry = info.Expiry,
                    Cvc = info.Cvc,
                    UserId = userId,
                    Image = await _cloudinaryApi.GetFileUrl(info.Issuer),
                });
            }

            var cards = await UnitOfWork.CreditCards.GetAllByUserId(userId);
            var result = new List<CreditCardInfo>();
            _mapper.Map(cards, result);

            return result;
        }

        public async Task<List<CreditCardInfo>> DeleteCreditCard(DeleteCreditCard info, int userId)
        {
            var card = await UnitOfWork.CreditCards.GetByNumber(info.Number);
            await UnitOfWork.CreditCards.Delete(card);
            var result = new List<CreditCardInfo>();
            var cards = await UnitOfWork.CreditCards.GetAllByUserId(userId);
            _mapper.Map(cards, result);
            return result;
        }

        public async Task<UserInfo> UpdateUserProfile(User user, UserUpdateProfile info)
        {
            _mapper.Map(info, user);
            await UnitOfWork.Users.Update(user);
            var result = new UserInfo
            {
                CreditCards = new List<CreditCardInfo>()
            };

            _mapper.Map(user, result);
            _mapper.Map(user.Cards, result.CreditCards);
            return result;
        }
    }
}
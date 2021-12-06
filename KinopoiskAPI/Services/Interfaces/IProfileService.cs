using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<CreditCardInfoDto>> AddCreditCard(AddCreditCardDto info, int userId);

        public Task<List<CreditCardInfoDto>> DeleteCreditCard(DeleteCreditCardDto info, int userId);

        public Task<UserInfoDto> UpdateUserProfile(User user, UserUpdateProfileDto info);
    }
}
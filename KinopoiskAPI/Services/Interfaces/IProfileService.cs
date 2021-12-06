using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.CreditCard;
using KinopoiskAPI.Dto.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<CreditCardInfo>> AddCreditCard(AddCreditCard info, int userId);

        public Task<List<CreditCardInfo>> DeleteCreditCard(DeleteCreditCard info, int userId);

        public Task<UserInfo> UpdateUserProfile(User user, UserUpdateProfile info);
    }
}
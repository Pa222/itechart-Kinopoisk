using System.Collections.Generic;
using System.Threading.Tasks;
using KinopoiskAPI.Dto.CreditCard;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<List<CreditCardInfoDto>> AddCreditCard(AddCreditCardDto info, int userId);

        public Task<List<CreditCardInfoDto>> DeleteCreditCard(DeleteCreditCardDto info, int userId);
    }
}
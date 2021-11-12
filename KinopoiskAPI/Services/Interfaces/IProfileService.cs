using System.Threading.Tasks;
using KinopoiskAPI.Dto.CreditCard;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<CreditCardInfoDto> AddCreditCard(AddCreditCardDto info, int userId);
    }
}
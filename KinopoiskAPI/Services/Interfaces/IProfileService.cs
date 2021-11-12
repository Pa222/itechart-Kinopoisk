using System.Threading.Tasks;
using KinopoiskAPI.Dto.CreditCard;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IProfileService
    {
        public Task<bool> AddCreditCard(AddCreditCardDto info, int userId);
    }
}
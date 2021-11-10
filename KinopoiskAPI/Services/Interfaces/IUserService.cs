using System.Threading.Tasks;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(string email);
    }
}
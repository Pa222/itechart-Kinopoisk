using Data_Access_Layer.Model;
using KinopoiskAPI.Dto;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(string email);

        public string GetToken(User user);

        public UserInfoDto GetUserInfo(User user);
    }
}
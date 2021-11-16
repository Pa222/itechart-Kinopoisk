using KinopoiskAPI.Dto;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.User;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(string email);

        public string GetToken(User user);

        public UserInfoDto GetUserInfo(User user);

        public Task<bool> AddUser(UserRegisterDto info);

        public Task<bool> UpdateUser(User user);
    }
}
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

        public Task<User> AddUser(UserRegisterDto info);

        public Task<User> UpdateUser(User user);
    }
}
using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.User;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(string email);

        public string GetToken(User user);

        public UserInfo GetUserInfo(User user);

        public Task<User> AddUser(UserRegister info);

        public Task<User> UpdateUser(User user);
    }
}
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByEmail(string email);
    }
}
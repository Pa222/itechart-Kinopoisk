using Data_Access_Layer.Interfaces;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByEmail(string email);
    }
}
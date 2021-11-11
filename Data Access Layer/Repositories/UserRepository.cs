using Data_Access_Layer.Model;
using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await Db.Users.Include(s => s.Cards).AsNoTracking().FirstOrDefaultAsync(u => u.Email.Equals(email)); ;
        }
    }
}
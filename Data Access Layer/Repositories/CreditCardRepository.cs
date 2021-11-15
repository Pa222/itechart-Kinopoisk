using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Model;
using Data_Access_Layer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class CreditCardRepository : GenericRepository<CreditCard>, ICreditCardRepository
    {
        public CreditCardRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<CreditCard> GetByNumber(string number)
        {
            return await Db.CreditCards.AsNoTracking().FirstOrDefaultAsync(c => c.Number.Equals(number));
        }

        public async Task<List<CreditCard>> GetAllByUserId(int userId)
        {
            return await Db.CreditCards.AsNoTracking().Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<bool> DeleteByNumber(string number)
        {
            var card = await Db.CreditCards.AsNoTracking().FirstOrDefaultAsync(c => c.Number.Equals(number));
            if (card == null) return false;
            Db.CreditCards.Remove(card);
            await Db.SaveChangesAsync();
            return true;
        }
    }
}
using Data_Access_Layer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        public Task<CreditCard> GetByNumber(string number);

        public Task<List<CreditCard>> GetAllByUserId(int userId);
    }
}
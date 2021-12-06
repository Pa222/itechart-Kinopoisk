using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        public Task<CreditCard> GetByNumber(string number);

        public Task<List<CreditCard>> GetAllByUserId(int userId);
    }
}
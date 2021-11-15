using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ICreditCardRepository : IRepository<CreditCard>
    {
        public Task<CreditCard> GetByNumber(string number);

        public Task<List<CreditCard>> GetAllByUserId(int userId);

        public Task<bool> DeleteByNumber(string number);
    }
}
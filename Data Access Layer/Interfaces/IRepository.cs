using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> Get(int id);

        void Create(T item);

        void Update(T item);

        void Delete(T item);
    }
}
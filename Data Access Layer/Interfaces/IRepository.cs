using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<ICollection<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Create(T item);

        Task<T> Update(T item);

        Task<bool> Delete(T item);
    }
}
using Data_Access_Layer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext Db;

        public GenericRepository(AppDbContext db)
        {
            Db = db;
        }

        public async Task<ICollection<T>> GetAll()
        {
            var tmp = await Db.Set<T>().ToListAsync();
            return await Db.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public async Task<bool> Create(T item)
        {
            Db.Set<T>().Add(item);
            return await Db.SaveChangesAsync() != 0;
        }

        public async Task<bool> Update(T item)
        {
            if (item == null) return false;
            Db.Set<T>().Update(item);
            return await Db.SaveChangesAsync() != 0;
        }

        public async Task<bool> Delete(T item)
        {
            if (item == null) return false;
            Db.Set<T>().Remove(item);
            return await Db.SaveChangesAsync() != 0;
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;

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
            return await Db.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await Db.Set<T>().FindAsync(id);
        }

        public async void Create(T item)
        {
            Db.Set<T>().Add(item);
            await Db.SaveChangesAsync();
        }

        public async void Update(T item)
        {
            if (item == null) return;
            Db.Set<T>().Update(item);
            await Db.SaveChangesAsync();
        }

        public async void Delete(T item)
        {
            if (item == null) return;
            Db.Set<T>().Remove(item);
            await Db.SaveChangesAsync();
        }
    }
}
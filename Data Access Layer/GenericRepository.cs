using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> Get(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public async void Create(T item)
        {
            _db.Set<T>().Add(item);
            await _db.SaveChangesAsync();
        }

        public async void Update(T item)
        {
            if (item == null) return;
            _db.Set<T>().Update(item);
            await _db.SaveChangesAsync();
        }

        public async void Delete(T item)
        {
            if (item == null) return;
            _db.Set<T>().Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
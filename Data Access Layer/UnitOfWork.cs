using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using Data_Access_Layer.Repositories;

namespace Data_Access_Layer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;

        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }

        public IMovieRepository Movies => new MovieRepository(_db);
        public IRepository<Genre> Genres => new GenericRepository<Genre>(_db);
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext db) : base(db)
        {
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _db.Movies.Include(s => s.GenreMovies).ThenInclude(s => s.Genre).AsNoTracking().ToListAsync();
        }

        public async Task<Movie> GetAsync(int id)
        {
            return await _db.Movies.Include(s => s.GenreMovies).ThenInclude(s => s.Genre).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Movie>> GetAllAsync()
        {
            return await Db.Movies.Include(s => s.GenreMovies).ThenInclude(s => s.Genre).AsNoTracking().ToListAsync();
        }

        public async Task<List<Movie>> GetPageAsync(int pageNumber, int pageSize)
        {
            var delta = pageNumber == 1 ? 0 : pageNumber - 1;
            return await Db.Movies.Include(s => s.GenreMovies).ThenInclude(s => s.Genre)
                .Skip(delta * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        /////////////////////
        public decimal GetAmountOfMovies()
        {
            return Db.Movies.Count();
        }

        /////////////////////

        public async Task<Movie> GetAsync(int id)
        {
            return await Db.Movies.Include(s => s.GenreMovies).ThenInclude(s => s.Genre).AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
using Data_Access_Layer.Model;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
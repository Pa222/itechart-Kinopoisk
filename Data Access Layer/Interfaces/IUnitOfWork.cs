using Data_Access_Layer.Model;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Movie> Movies { get; }
        IRepository<Genre> Genres { get; }
    }
}
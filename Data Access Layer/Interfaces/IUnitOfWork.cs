using Data_Access_Layer.Model;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IRepository<Genre> Genres { get; }
    }
}
using Data_Access_Layer.Model;
using Data_Access_Layer.Repositories.Interfaces;

namespace Data_Access_Layer.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository Movies { get; }
        IRepository<Genre> Genres { get; }
        IRepository<Faq> Faqs { get; }
        IRepository<CreditCard> CreditCards { get; }
        IUserRepository Users { get; }
    }
}
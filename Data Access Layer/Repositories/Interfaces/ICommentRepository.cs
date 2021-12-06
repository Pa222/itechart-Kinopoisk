using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public Task<List<Comment>> GetAllByMovie(int id);
    }
}
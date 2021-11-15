using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.Model;

namespace Data_Access_Layer.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public Task<List<Comment>> GetAllByMovie(int id);
    }
}
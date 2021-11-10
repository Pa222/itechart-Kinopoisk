using Data_Access_Layer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IFaqService
    {
        public Task<ICollection<Faq>> GetAll();
    }
}
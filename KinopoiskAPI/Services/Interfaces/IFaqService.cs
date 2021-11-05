using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Model;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IFaqService
    {
        public Task<ICollection<Faq>> GetAll();
    }
}
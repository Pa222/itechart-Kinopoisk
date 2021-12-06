using Data_Access_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IFaqService
    {
        public Task<ICollection<Faq>> GetAll();
    }
}
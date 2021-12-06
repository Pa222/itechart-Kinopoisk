using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class FaqService : GenericService, IFaqService
    {
        public FaqService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ICollection<Faq>> GetAll()
        {
            return await UnitOfWork.Faqs.GetAll();
        }
    }
}
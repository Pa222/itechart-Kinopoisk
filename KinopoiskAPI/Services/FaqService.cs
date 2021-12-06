using Data_Access_Layer.Entity;
using Data_Access_Layer.Interfaces;
using KinopoiskAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KinopoiskAPI.Services
{
    public class FaqService : IFaqService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaqService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Faq>> GetAll()
        {
            return await _unitOfWork.Faqs.GetAll();
        }
    }
}
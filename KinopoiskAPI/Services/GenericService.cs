using Data_Access_Layer.Interfaces;

namespace KinopoiskAPI.Services
{
    public class GenericService
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
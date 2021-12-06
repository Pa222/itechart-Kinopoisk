using Data_Access_Layer.Interfaces;

namespace KinopoiskAPI.Services
{
    public class GenericService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public GenericService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
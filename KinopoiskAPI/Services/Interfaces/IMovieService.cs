using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Model;
using KinopoiskAPI.Dto;

namespace KinopoiskAPI.Services.Interfaces
{
    public interface IMovieService
    {
        public Task<MoviePageDto> GetPage(int pageNumber);

        public Task<MovieInfoDto> Get(int id);
    }
}
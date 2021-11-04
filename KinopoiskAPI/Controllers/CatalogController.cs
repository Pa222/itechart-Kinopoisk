using System.Threading.Tasks;
using KinopoiskAPI.Dto;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class CatalogController : Controller
    {
        private readonly IMovieService _movieService;

        public CatalogController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movies = await _movieService.Get(id);
            return Ok(movies);
        }

        [HttpGet("get-page/{pageNumber}")]
        public async Task<IActionResult> GetPage(int pageNumber)
        {
            var movies = await _movieService.GetPage(new MoviePageDto() { PageNumber = pageNumber });
            return Ok(movies);
        }
    }
}
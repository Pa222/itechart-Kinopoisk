using System.Threading.Tasks;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KinopoiskAPI.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IMovieService _movieService;

        public CatalogController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("api/[controller]/get")]
        public async Task<IActionResult> Get()
        {
            var movies = await _movieService.GetAll();
            var json = JsonConvert.SerializeObject(movies);
            return Ok(json);
        }

        [HttpGet("{id:int}")]
        [Route("api/[controller]/get")]
        public async Task<IActionResult> Get(int id)
        {
            var movies = await _movieService.Get(id);
            var json = JsonConvert.SerializeObject(movies);
            return Ok(json);
        }
    }
}
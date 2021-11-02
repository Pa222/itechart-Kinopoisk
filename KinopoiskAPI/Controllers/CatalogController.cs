using Microsoft.AspNetCore.Mvc;

namespace KinopoiskAPI.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet]
        [Route("[controller]/get-movies")]
        public IActionResult GetMovies()
        {
            return Json("test");
        }
    }
}
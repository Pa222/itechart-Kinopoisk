using KinopoiskAPI.Dto.Comment;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public CommentsController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [Authorize]
        [HttpPost("addComment")]
        public async Task<IActionResult> AddComment([FromBody] AddCommentDto info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
                return BadRequest();

            var comments = await _movieService.AddComment(info, user.Id);

            return Ok(comments);
        }

        [Authorize]
        [HttpDelete("deleteComment")]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteCommentDto info)
        {
            if (info == null)
                return BadRequest();
            var comments = await _movieService.DeleteComment(info);
            return Ok(comments);
        }
    }
}
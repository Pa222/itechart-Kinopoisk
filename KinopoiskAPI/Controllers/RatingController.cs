using AutoMapper;
using Data_Access_Layer.Entity;
using KinopoiskAPI.Dto.Rating;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace KinopoiskAPI.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRatingService _ratingService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public RatingController(IUserService userService, IRatingService ratingService, IMapper mapper, IMovieService movieService)
        {
            _userService = userService;
            _ratingService = ratingService;
            _mapper = mapper;
            _movieService = movieService;
        }

        [Authorize]
        [HttpPost("update-rating")]
        public async Task<IActionResult> UpdateRating([FromBody] UpdateRatingDto info)
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var email = JwtDecoder.GetEmail(token[7..]);
            var user = await _userService.GetUser(email);

            if (user == null || info == null)
                return BadRequest();

            var rating = await _ratingService.GetRating(info.MovieId, user.Id);

            if (rating == null)
            {
                var updRating = _mapper.Map<UpdateRatingDto, Rating>(info);
                updRating.UserId = user.Id;
                var result = await _ratingService.CreateRating(updRating);
                if (result != null)
                    return Ok(await _movieService.Get(info.MovieId));
            }
            else
            {
                _mapper.Map(info, rating);
                var result = await _ratingService.UpdateRating(rating);
                if (result != null)
                    return Ok(await _movieService.Get(info.MovieId));
            }

            return BadRequest();
        }
    }
}
using CinemaWebApi.BusinessLayer.Services;
using CinemaWebApi.Shared.Models;
using CinemaWebApi.Shared.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet("GetMovie/{title}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMovie(string title)
        {
            var movie = await moviesService.GetMovieAsync(title);
            return movie != null ? Ok(movie) : NotFound("Movie not found");
        }

        [HttpPost("RegisterMovie")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterMovie(RegisterMovieRequest request)
        {
            var result = await moviesService.AddMovieAsync(request);
            return result ? Ok("movies successfully added") : BadRequest("errors during registration");
        }
    }
}
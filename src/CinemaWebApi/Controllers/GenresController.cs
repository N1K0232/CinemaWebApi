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
    public class GenresController : ControllerBase
    {
        private readonly IGenresService genresService;

        public GenresController(IGenresService genresService)
        {
            this.genresService = genresService;
        }

        [HttpGet("GetGenre")]
        [ProducesResponseType(200, Type = typeof(Genre))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetGenre(string name)
        {
            var genre = await genresService.GetGenreAsync(name);
            return genre != null ? Ok(genre) : NotFound("genre not found");
        }

        [HttpPost("RegisterGenre")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RegisterGenre([FromBody] RegisterGenreRequest request)
        {
            var result = await genresService.AddGenreAsync(request);
            return result ? Ok("genre successfully added") : BadRequest("errors during adding");
        }
    }
}
using Data.Models;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            return await _moviesService.GetMovies();
        }

        [HttpPost]
        [Route("[action]")]
        // FromBody is optional here
        public async Task AddMovie([FromBody] Movie movie)
        {
            await _moviesService.AddMovie(movie);
            // return createda action
        }
    }
}

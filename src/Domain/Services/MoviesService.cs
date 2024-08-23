using Data.DatabaseContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly MoviesContext _moviesContext;

        public MoviesService(MoviesContext moviesContext)
        {
            _moviesContext = moviesContext;
        }

        public Task<List<Movie>> GetMovies()
        {
            return _moviesContext.Movies.ToListAsync();
        }

        public Task AddMovie(Movie movie)
        {
            _moviesContext.Movies.Add(movie);
            return _moviesContext.SaveChangesAsync();
        }
    }
}

using Data.Models;

namespace Domain.Services
{
    public interface IMoviesService
    {
        Task AddMovie(Movie movie);
        Task<List<Movie>> GetMovies();
    }
}
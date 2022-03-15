using CinemaWebApi.Shared.Models.Requests;
using System.Threading.Tasks;

using ApplicationMovie = CinemaWebApi.Shared.Models.Movie;

namespace CinemaWebApi.BusinessLayer.Services
{
    public interface IMoviesService
    {
        Task<bool> AddMovieAsync(RegisterMovieRequest request);
        Task<bool> DeleteMovieAsync(string title);
        Task<ApplicationMovie> GetMovieAsync(string title);
        Task<bool> UpdateMovieAsync();
    }
}
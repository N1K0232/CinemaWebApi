using CinemaWebApi.Shared.Models;
using CinemaWebApi.Shared.Models.Requests;
using System.Threading.Tasks;

namespace CinemaWebApi.BusinessLayer.Services
{
    public interface IGenresService
    {
        Task<bool> AddGenreAsync(RegisterGenreRequest request);
        Task<bool> DeleteGenreAsync(string name);
        Task<Genre> GetGenreAsync(string name);
        Task<bool> UpdateGenreAsync();
    }
}
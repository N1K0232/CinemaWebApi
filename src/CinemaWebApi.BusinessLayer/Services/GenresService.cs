using CinemaWebApi.DataAccessLayer;
using CinemaWebApi.DataAccessLayer.Entities;
using CinemaWebApi.Shared.Models.Requests;
using System.Threading.Tasks;

using ApplicationGenre = CinemaWebApi.Shared.Models.Genre;

namespace CinemaWebApi.BusinessLayer.Services
{
    public class GenresService : IGenresService
    {
        private readonly IDataContext dataContext;

        public GenresService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> AddGenreAsync(RegisterGenreRequest request)
        {
            var genre = new Genre
            {
                Name = request.Name,
                Description = request.Description,
            };

            dataContext.Insert(genre);
            return await dataContext.SaveAsync();
        }
        public async Task<bool> DeleteGenreAsync(string name)
        {
            var genre = await dataContext.GetAsync<Genre>(name);
            if (genre == null)
            {
                return false;
            }

            dataContext.Delete(genre);
            return await dataContext.SaveAsync();
        }
        public async Task<ApplicationGenre> GetGenreAsync(string name)
        {
            var genre = await dataContext.GetAsync<Genre>(name);
            var applicationGenre = new ApplicationGenre
            {
                Name = genre.Name,
                Description = genre.Description
            };

            return applicationGenre;
        }
        public Task<bool> UpdateGenreAsync()
            => Task.FromResult(true);
    }
}
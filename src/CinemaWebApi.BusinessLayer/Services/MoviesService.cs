using CinemaWebApi.DataAccessLayer;
using CinemaWebApi.DataAccessLayer.Entities;
using CinemaWebApi.Shared.Models.Requests;
using System.Threading.Tasks;

using ApplicationGenre = CinemaWebApi.Shared.Models.Genre;
using ApplicationMovie = CinemaWebApi.Shared.Models.Movie;

namespace CinemaWebApi.BusinessLayer.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IDataContext dataContext;

        public MoviesService(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<bool> AddMovieAsync(RegisterMovieRequest request)
        {
            var genre = await dataContext.GetAsync<Genre>(request.Genre);
            var movie = new Movie
            {
                Title = request.Title,
                OriginalTitle = request.OriginalTitle,
                Language = request.Language,
                OriginalLanguage = request.OriginalLanguage,
                ReleaseDate = request.ReleaseDate,
                Genre = genre,
            };

            dataContext.Insert(movie);
            return await dataContext.SaveAsync();
        }
        public async Task<bool> DeleteMovieAsync(string title)
        {
            var movie = await dataContext.GetAsync<Movie>(title);
            if (movie == null)
            {
                return false;
            }

            dataContext.Delete(movie);
            return await dataContext.SaveAsync();
        }
        public async Task<ApplicationMovie> GetMovieAsync(string title)
        {
            var movie = await dataContext.GetAsync<Movie>(title);
            var genre = await dataContext.GetAsync<Genre>(movie.GenreId);
            var applicationMovie = new ApplicationMovie
            {
                Title = movie.Title,
                OriginalTitle = movie.OriginalTitle,
                Language = movie.Language,
                OriginalLanguage = movie.OriginalLanguage,
                ReleaseDate = movie.ReleaseDate,
                Genre = new ApplicationGenre
                {
                    Name = genre.Name,
                    Description = genre.Description
                }
            };

            return applicationMovie;
        }

        public Task<bool> UpdateMovieAsync()
            => Task.FromResult(true);
    }
}
using System;

namespace CinemaWebApi.Shared.Models.Requests
{
    public class RegisterMovieRequest
    {
        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string Language { get; set; }

        public string OriginalLanguage { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; }
    }
}
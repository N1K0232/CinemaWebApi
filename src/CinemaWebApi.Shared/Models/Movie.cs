using System;

namespace CinemaWebApi.Shared.Models
{
    public class Movie
    {
        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string Language { get; set; }

        public string OriginalLanguage { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }
    }
}
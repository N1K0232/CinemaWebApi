using CinemaWebApi.DataAccessLayer.Entities.Common;
using System;

namespace CinemaWebApi.DataAccessLayer.Entities
{
    public class Movie : BaseEntity
    {
        public Guid GenreId { get; set; }

        public string Title { get; set; }

        public string OriginalTitle { get; set; }

        public string Language { get; set; }

        public string OriginalLanguage { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
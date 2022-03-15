using CinemaWebApi.DataAccessLayer.Entities.Common;
using System.Collections.Generic;

namespace CinemaWebApi.DataAccessLayer.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
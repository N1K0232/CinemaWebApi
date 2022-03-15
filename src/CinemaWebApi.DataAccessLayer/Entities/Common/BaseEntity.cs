using System;

namespace CinemaWebApi.DataAccessLayer.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
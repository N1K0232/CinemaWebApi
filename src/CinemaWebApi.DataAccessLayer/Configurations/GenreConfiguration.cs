using CinemaWebApi.DataAccessLayer.Configurations.Common;
using CinemaWebApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWebApi.DataAccessLayer.Configurations
{
    internal sealed class GenreConfiguration : BaseEntityConfiguration<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> builder)
        {
            base.Configure(builder);
            builder.Property(genre => genre.Name).HasMaxLength(256).IsRequired();
            builder.Property(genre => genre.Description).HasMaxLength(512);
        }
    }
}
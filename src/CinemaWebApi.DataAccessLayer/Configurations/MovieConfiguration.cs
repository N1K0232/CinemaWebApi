using CinemaWebApi.DataAccessLayer.Configurations.Common;
using CinemaWebApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaWebApi.DataAccessLayer.Configurations
{
    internal sealed class MovieConfiguration : BaseEntityConfiguration<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            base.Configure(builder);
            builder.Property(movie => movie.Title).HasMaxLength(256).IsRequired();
            builder.Property(movie => movie.OriginalTitle).HasMaxLength(256).IsRequired();
            builder.Property(movie => movie.ReleaseDate).IsRequired();
            builder.Property(movie => movie.Language).HasMaxLength(50).IsRequired();
            builder.Property(movie => movie.OriginalTitle).HasMaxLength(50).IsRequired();

            builder.HasOne(movie => movie.Genre)
                .WithMany(genre => genre.Movies)
                .HasForeignKey(movie => movie.GenreId);
        }
    }
}
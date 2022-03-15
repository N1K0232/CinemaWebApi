using CinemaWebApi.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace CinemaWebApi.DataAccessLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type dataContextType = typeof(DataContext);
            Assembly currentAssembly = dataContextType.Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
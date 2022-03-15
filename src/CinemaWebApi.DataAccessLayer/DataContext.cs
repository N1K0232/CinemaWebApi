using CinemaWebApi.DataAccessLayer.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace CinemaWebApi.DataAccessLayer
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            Set<T>().Remove(entity);
        }
        public void Edit<T>(T entity) where T : BaseEntity
        {
            Set<T>().Update(entity);
        }
        public async ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity
        {
            return await Set<T>().FindAsync(keyValues);
        }
        public void Insert<T>(T entity) where T : BaseEntity
        {
            Set<T>().Add(entity);
        }
        public async Task<bool> SaveAsync()
        {
            bool result;

            try
            {
                await SaveChangesAsync();
                result = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                result = false;
            }
            catch (DbUpdateException)
            {
                result = false;
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Type dataContextType = typeof(DataContext);
            Assembly currentAssembly = dataContextType.Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
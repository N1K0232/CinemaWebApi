using CinemaWebApi.DataAccessLayer.Entities.Common;
using System.Threading.Tasks;

namespace CinemaWebApi.DataAccessLayer
{
    public interface IDataContext
    {
        void Delete<T>(T entity) where T : BaseEntity;
        void Edit<T>(T entity) where T : BaseEntity;
        ValueTask<T> GetAsync<T>(params object[] keyValues) where T : BaseEntity;
        void Insert<T>(T entity) where T : BaseEntity;
        Task<bool> SaveAsync();
    }
}
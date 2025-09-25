using Microsoft.EntityFrameworkCore.Storage;

namespace Hospital.Infrastructure.InfrastructureBase
{
    public interface IGenericRepos<T> where T : class
    {
        Task DeleteRangeAsync(ICollection<T> entities);
        public Task<List<T>> GetAllAsync();


        Task<T> GetByIdAsync(int id);
        Task SaveChangesAsync();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
        Task AddRangeAsync(ICollection<T> entities);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(ICollection<T> entities);
        Task DeleteAsync(T entity);
    }
}

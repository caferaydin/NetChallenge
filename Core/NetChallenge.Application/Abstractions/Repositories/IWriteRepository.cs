using NetChallenge.Domain.Entities.Common;

namespace NetChallenge.Application.Abstractions.Repository
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(List<T> datas);
        bool Update(T entity);
        Task<int> SaveAsync();
    }
}

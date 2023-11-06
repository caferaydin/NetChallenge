using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetChallenge.Application.Abstractions.Repository;
using NetChallenge.Domain.Entities.Common;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        #region Fields
        readonly private MsSqlDbContext _context;
        #endregion

        #region Ctor
        public WriteRepository(MsSqlDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Method

        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }


        public bool Update(T entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository;
using NetChallenge.Domain.Entities.Common;
using NetChallenge.Persistence.Context;
using System.Linq.Expressions;

namespace NetChallenge.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly MsSqlDbContext _context;

        #endregion

        #region Ctor

        public ReadRepository(MsSqlDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Method

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();

            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();

            return await query.FirstOrDefaultAsync(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = Table.AsNoTracking();
            return query;
        }
        #endregion
    }
}

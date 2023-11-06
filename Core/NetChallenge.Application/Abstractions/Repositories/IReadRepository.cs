using NetChallenge.Domain.Entities.Common;
using System.Linq.Expressions;

namespace NetChallenge.Application.Abstractions.Repository
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter, bool tracking = true);
        Task<T> GetByIdAsync(int id, bool tracking = true);

    }
}

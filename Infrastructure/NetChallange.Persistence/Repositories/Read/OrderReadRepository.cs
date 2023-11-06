using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Read
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        #region Ctor
        public OrderReadRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion
    }
}

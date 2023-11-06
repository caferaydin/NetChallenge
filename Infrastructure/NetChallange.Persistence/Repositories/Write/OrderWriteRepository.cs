using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Write
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        #region Ctor
        public OrderWriteRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion
    }
}

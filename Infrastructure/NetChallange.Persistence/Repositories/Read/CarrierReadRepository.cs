using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Read
{
    public class CarrierReadRepository : ReadRepository<Carrier>, ICarrierReadRepository
    {
        #region Ctor
        public CarrierReadRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion
    }
}

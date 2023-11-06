using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Read
{
    public class CarrierConfigurationReadRepository : ReadRepository<CarrierConfiguration>, ICarrierConfigurationReadRepository
    {
        #region Ctor
        public CarrierConfigurationReadRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion

    }
}

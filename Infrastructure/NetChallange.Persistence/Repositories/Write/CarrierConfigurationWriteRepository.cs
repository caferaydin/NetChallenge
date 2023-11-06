using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Write
{
    public class CarrierConfigurationWriteRepository : WriteRepository<CarrierConfiguration>, ICarrierConfigurationWriteRepository
    {
        #region Ctor
        public CarrierConfigurationWriteRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion
    }
}

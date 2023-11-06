using NetChallenge.Application.Abstractions.Repository.Write;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Write
{
    public class CarrierWriteRepository : WriteRepository<Carrier>, ICarrierWriteRepository
    {
        #region Ctor
        public CarrierWriteRepository(MsSqlDbContext context) : base(context)
        {
        }
        #endregion
    }
}

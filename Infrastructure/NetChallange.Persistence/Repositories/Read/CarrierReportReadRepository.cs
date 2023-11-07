using NetChallenge.Application.Abstractions.Repositories.Read;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;

namespace NetChallenge.Persistence.Repositories.Read
{
    public class CarrierReportReadRepository : ReadRepository<CarrierReport>, ICarrierReportReadRepository
    {
        public CarrierReportReadRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}

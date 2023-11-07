using NetChallenge.Application.Abstractions.Repositories.Write;
using NetChallenge.Domain.Entities;
using NetChallenge.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence.Repositories.Write
{
    public class CarrierReportWriteRepository : WriteRepository<CarrierReport>, ICarrierReportWriteRepository
    {
        public CarrierReportWriteRepository(MsSqlDbContext context) : base(context)
        {
        }
    }
}

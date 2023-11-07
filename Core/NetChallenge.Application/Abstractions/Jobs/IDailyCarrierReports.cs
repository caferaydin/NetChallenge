using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Abstractions.Jobs
{
    public interface IDailyCarrierReports
    {
        Task AddDailyCarrierReports();
    }
}

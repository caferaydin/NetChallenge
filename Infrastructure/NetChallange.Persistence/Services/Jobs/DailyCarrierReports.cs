using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Jobs;
using NetChallenge.Application.Abstractions.Repositories.Write;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Domain.Entities;

namespace NetChallenge.Persistence.Services.Jobs
{
    public class DailyCarrierReports : IDailyCarrierReports
    {
        #region Fields

        private readonly IOrderReadRepository _orderReadRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierReportWriteRepository _carrierReportWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;

        #endregion

        #region Ctor
        public DailyCarrierReports(IOrderReadRepository orderReadRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierReportWriteRepository carrierReportWriteRepository, ICarrierReadRepository carrierReadRepository)
        {
            _orderReadRepository = orderReadRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierReportWriteRepository = carrierReportWriteRepository;
            _carrierReadRepository = carrierReadRepository;
        }
        #endregion


        public async Task AddDailyCarrierReports()
        {
            var groupedOrders = _orderReadRepository.Table
               .Include(o => o.Carrier)
               .GroupBy(o => new { o.Carrier.Id, o.OrderDate })
               .Select(g => new
               {
                   CarrierId = g.Key.Id,
                   ReportDate = DateTime.Now,
                   CarrierCost = g.Sum(o => o.OrderCarrierCost)
               });

            var carrierReports = groupedOrders.Select(order => new CarrierReport
            {
                CarrierId = order.CarrierId,
                CarrierReportDate = order.ReportDate,
                CarrierCost = order.CarrierCost
            }).ToList();

             _carrierReportWriteRepository.AddRangeAsync(carrierReports);
            await _carrierReportWriteRepository.SaveAsync();
        }
    }
}

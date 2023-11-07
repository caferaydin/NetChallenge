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
            IEnumerable<Order> orders = _orderReadRepository.Table.Include(o => o.Carrier);

            var groupedOrders = orders.GroupBy(o => new { o.Carrier, o.OrderDate });

            Dictionary<int, decimal> carrierCosts = new Dictionary<int, decimal>();
            foreach (var group in groupedOrders)
            {
                var carrier = group.Key.Carrier;
                var totalCarrierCost = group.Sum(o => o.OrderCarrierCost);

                if (!carrierCosts.ContainsKey(carrier.Id))
                {
                    carrierCosts[carrier.Id] = totalCarrierCost;
                }
                else
                {
                    carrierCosts[carrier.Id] += totalCarrierCost;
                }
            }

            // CarrierReport nesnelerini oluştur ve veritabanına kaydet
            foreach (var entry in carrierCosts)
            {
                await _carrierReportWriteRepository.AddAsync(new CarrierReport
                {
                    CarrierId = entry.Key,
                    CarrierReportDate = DateTime.Now,
                    CarrierCost = entry.Value
                });
            }

            // Değişiklikleri kaydet
            await _carrierReportWriteRepository.SaveAsync();
        }
    }
}

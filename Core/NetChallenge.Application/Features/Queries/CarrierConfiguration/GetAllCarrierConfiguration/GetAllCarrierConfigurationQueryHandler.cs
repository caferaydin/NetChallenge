using MediatR;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;

namespace NetChallenge.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryHandler : IRequestHandler<GetAllCarrierConfigurationQueryRequest, GetAllCarrierConfigurationQueryReponse>
    {
        private readonly ICarrierConfigurationReadRepository _readRepository;

        public GetAllCarrierConfigurationQueryHandler(ICarrierConfigurationReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAllCarrierConfigurationQueryReponse> Handle(GetAllCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCarrierConfigurationCount = _readRepository.GetAll(false).Count();

            var carrierConfigurations = _readRepository.GetAll(false)
                .Include(cf => cf.Carrier)
                .Select(c => new
                {
                    c.Carrier,
                    c.CarrierMinDesi,
                    c.CarrierMaxDesi,
                    c.CarrierCost
                }).ToList();

            return new()
            {
                CarrierConfiguarions = carrierConfigurations,
                IsSuccess = true,
                TotalCarrierConfigurationCount = totalCarrierConfigurationCount,
            };
        }
    }
}

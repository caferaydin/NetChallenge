using MediatR;
using NetChallenge.Application.Abstractions.Repository.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration
{
    public class GetByCarrierConfigurationQueryHandler : IRequestHandler<GetByIdCarrierConfigurationQueryRequest, GetByIdCarrierConfigurationQueryResponse>
    {
        #region Fields

        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        #endregion

        #region Ctor

        public GetByCarrierConfigurationQueryHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        #endregion
        public async Task<GetByIdCarrierConfigurationQueryResponse> Handle(GetByIdCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            var carrierConfiguration = await _carrierConfigurationReadRepository.GetByIdAsync(request.Id);

            return new()
            {
                Id = request.Id,
                CarrierId = carrierConfiguration.CarrierId,
                CarrierMinDesi = carrierConfiguration.CarrierMinDesi,
                CarrierMaxDesi = carrierConfiguration.CarrierMaxDesi,
                CarrierCost = carrierConfiguration.CarrierCost,
            };

        }
    }
}

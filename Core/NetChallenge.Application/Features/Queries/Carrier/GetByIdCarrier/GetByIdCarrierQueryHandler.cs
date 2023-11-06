using MediatR;
using NetChallenge.Application.Abstractions.Repository.Read;

namespace NetChallenge.Application.Features.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryHandler : IRequestHandler<GetByIdCarrierQueryRequest, GetByIdCarrierQueryResponse>
    {
        #region Fields

        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;

        #endregion

        #region Ctor

        public GetByIdCarrierQueryHandler(ICarrierReadRepository carrierReadRepository, ICarrierConfigurationReadRepository carrierConfigurationReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
        }

        #endregion

        #region Method

        public async Task<GetByIdCarrierQueryResponse> Handle(GetByIdCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var carrier = await _carrierReadRepository.GetByIdAsync(request.Id);

            return new()
            {
                Id = carrier.Id,
                CarrierName = carrier.CarrierName,
                CarrierIsActive = carrier.CarrierIsActive,
                CarrierPlusDesiCost = carrier.CarrierPlusDesiCost,
                CarrierConfigurationId = carrier.CarrierConfigurationId,
            };
        }

        #endregion
    }
}

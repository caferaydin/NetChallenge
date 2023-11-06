using MediatR;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;

namespace NetChallenge.Application.Features.Queries.Carrier.GetAllCarirer
{
    public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQueryRequest, GetAllCarrierQueryResponse>
    {
        #region Fields

        private readonly ICarrierReadRepository _carrierReadRepository;

        #endregion

        #region Ctor

        public GetAllCarrierQueryHandler(ICarrierReadRepository carrierReadRepository)
        {
            _carrierReadRepository = carrierReadRepository;
        }

        #endregion

        #region Method

        public async Task<GetAllCarrierQueryResponse> Handle(GetAllCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCarrierCount = _carrierReadRepository.GetAll(false).Count();

            var carriers = _carrierReadRepository.GetAll(false)
                .Include(c => c.CarrierConfigurations)
                .Select(c => new
                {
                    c.CarrierName,
                    c.CarrierPlusDesiCost,
                    c.CarrierIsActive,
                    c.CarrierConfigurations,
                }).ToList();

            return new()
            {
                Carriers = carriers,
                TotalCarrierCount = totalCarrierCount,
                Success = true,
            };
        }

        #endregion
    }
}

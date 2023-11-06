using MediatR;

namespace NetChallenge.Application.Features.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryRequest : IRequest<GetByIdCarrierQueryResponse>
    {
        public int Id { get; set; }
    }
}

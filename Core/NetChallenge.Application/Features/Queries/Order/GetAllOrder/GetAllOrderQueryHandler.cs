using MediatR;
using Microsoft.EntityFrameworkCore;
using NetChallenge.Application.Abstractions.Repository.Read;
using NetChallenge.Application.Abstractions.Repository.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var totalOrderCount = _orderReadRepository.GetAll().Count();

            var orders =  _orderReadRepository.GetAll(false)
                .Include(o => o.Carrier)
                .Select(o => new
                {
                    o.Carrier,
                    o.OrderDesi,
                    o.OrderCarrierCost,
                    o.OrderDate
                }).ToList();


            return new()
            {
                Orders = orders,
                IsSuccess = true,
                TotalOrderCount = totalOrderCount,
            };

        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Commands.Order.CreateOrder
{
    public class OrderCreateCommandRequest : IRequest<OrderCreateCommandResponse>
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

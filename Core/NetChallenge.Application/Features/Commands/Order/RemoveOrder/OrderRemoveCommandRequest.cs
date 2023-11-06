using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Application.Features.Commands.Order.RemoveOrder
{
    public class OrderRemoveCommandRequest : IRequest<OrderRemoveCommandResponse>
    {
        public int Id { get; set; }
    }
}

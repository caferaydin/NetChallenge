using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.Features.Commands.Order.CreateOrder;
using NetChallenge.Application.Features.Commands.Order.RemoveOrder;
using NetChallenge.Application.Features.Queries.Order.GetAllOrder;
using NetChallenge.Application.Features.Queries.Order.GetByIdOrder;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public OrdersController( IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Method

        [HttpGet]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetAllOrderQueryRequest request)
        {
            GetAllOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _orderService.GetAllOrdersAsync());
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOrderQueryRequest request)
        {
            GetByIdOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _orderService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(OrderCreateCommandRequest request)
        {
            OrderCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(OrderRemoveCommandRequest request)
        {
            OrderRemoveCommandResponse response = await _mediator.Send(request); 
            return Ok(response);
            //return Ok(await _orderService.DeleteAsync(id));
        }
        #endregion

    }
}

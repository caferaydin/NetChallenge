using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.ViewModel.Order;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        #region Fields
        private readonly IOrderService _orderService;
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public OrdersController(IOrderService orderService, IMediator mediator)
        {
            _orderService = orderService;
            _mediator = mediator;
        }
        #endregion

        #region Method

        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await _orderService.GetAllOrdersAsync());
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _orderService.GetByIdAsync(id));
        }

        [HttpPost("createOrder")]
        public async Task<ActionResult> CreateOrder(CreateOrder request)
        {
            //CreateOrderCommandResponse response = await _mediator.Send(createOrderCommandRequest);
            //return Ok(response);

            return Ok(await _orderService.CreateOrderAsync(request));

        }

        [HttpDelete("deleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok(await _orderService.DeleteAsync(id));
        }
        #endregion

    }
}

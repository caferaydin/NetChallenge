using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.Features.Commands.Carrier.CreateCarrier;
using NetChallenge.Application.Features.Commands.Carrier.RemoveCarrier;
using NetChallenge.Application.Features.Commands.Carrier.UpdateCarrier;
using NetChallenge.Application.Features.Queries.Carrier.GetAllCarirer;
using NetChallenge.Application.Features.Queries.Carrier.GetByIdCarrier;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        #region Fields
        private readonly ICarrierService _carrierService;
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public CarriersController(ICarrierService carrierService, IMediator mediator)
        {
            _carrierService = carrierService;
            _mediator = mediator;
        }
        #endregion

        #region Method

        [HttpGet("getAllCarriers")]
        public async Task<IActionResult> GetAllCarriers([FromQuery]  GetAllCarrierQueryRequest request)
        {
            GetAllCarrierQueryResponse response = await _mediator.Send(request);
            return Ok(response); 
            //return Ok(await _carrierService.GetAllCarriersAsync());
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCarrierQueryRequest request) 
        {
            GetByIdCarrierQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierService.GetByIdAsync(id));
        }

        [HttpPost("createCarrier")]
        public  async Task<ActionResult> CreateCarrier(CarrierCreateCommandRequest request)
        {
            CarrierCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok( _carrierService.CreateCarrier(request));
        }

        [HttpPut("updateCarrier")]
        public async Task<IActionResult> UpdateCarrier([FromBody] CarrierUpdateCommandRequest request)
        {
            CarrierUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierService.UpdateCarrier(request));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(CarrierRemoveCommadRequest request)
        {
            CarrierRemoveCommandResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierService.DeleteAsync(id));
        }
        #endregion
    }
}

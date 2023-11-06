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

        [HttpGet]
        public async Task<IActionResult> GetAllCarriers([FromQuery]  GetAllCarrierQueryRequest request)
        {
            GetAllCarrierQueryResponse response = await _mediator.Send(request);
            return Ok(response); 
            //return Ok(await _carrierService.GetAllCarriersAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCarrierQueryRequest request) 
        {
            GetByIdCarrierQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierService.GetByIdAsync(id));
        }

        [HttpPost]
        public  async Task<IActionResult> CreateCarrier(CarrierCreateCommandRequest request)
        {
            CarrierCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok( _carrierService.CreateCarrier(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrier([FromBody] CarrierUpdateCommandRequest request)
        {
            CarrierUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(CarrierRemoveCommadRequest request)
        {
            CarrierRemoveCommandResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierService.DeleteAsync(id));
        }
        #endregion
    }
}

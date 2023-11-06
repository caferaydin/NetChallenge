using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.Features.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using NetChallenge.Application.Features.Commands.CarrierConfiguration.RemoveCarrierConfiguration;
using NetChallenge.Application.Features.Commands.CarrierConfiguration.UpdateCarrierConfiguration;
using NetChallenge.Application.Features.Queries.CarrierConfiguration.GetAllCarrierConfiguration;
using NetChallenge.Application.Features.Queries.CarrierConfiguration.GetByIdCarrierConfiguration;
using NetChallenge.Application.ViewModel.CarrierConfiguration;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        #region Fields
        private readonly IMediator _mediator;
        #endregion

        #region Ctor
        public CarrierConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Method

        [HttpGet]
        public async Task<IActionResult> GetCarrierConfigurations([FromQuery] GetAllCarrierConfigurationQueryRequest request)
        {
            GetAllCarrierConfigurationQueryReponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierConfigurationService.GetAllCarrierConfigurationsAsync());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCarrierConfigurationQueryRequest request)
        {
            GetByIdCarrierConfigurationQueryResponse response = await _mediator.Send(request);
            return Ok(response);
            //return Ok(await _carrierConfigurationService.GetByIdAsync(carrierConfigurationId));
        }

        [HttpPost]
        public async Task<ActionResult> CreateCarrierConfiguration(CarrierConfigurationCreateCommandRequest request)
        {
            CarrierConfigurationCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarrierConfugiration([FromBody]  CarrierConfigurationUpdateCommandRequest request)
        {
            CarrierConfigurationUpdateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierConfiguration(CarrierConfigurationRemoveCommandRequest request)
        {
            CarrierConfigurationRemoveCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        #endregion
    }
}

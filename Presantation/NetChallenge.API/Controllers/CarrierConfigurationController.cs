using Microsoft.AspNetCore.Mvc;
using NetChallenge.Application.Abstractions.Services;
using NetChallenge.Application.ViewModel.CarrierConfiguration;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        #region Fields
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        #endregion

        #region Ctor
        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }
        #endregion

        #region Method

        [HttpGet("getCarrierConfigurations")]
        public async Task<IActionResult> GetCarrierConfigurations()
        {
            return Ok(await _carrierConfigurationService.GetAllCarrierConfigurationsAsync());
        }

        [HttpGet("getById/{carrierConfigurationId}")]
        public async Task<IActionResult> GetById(int carrierConfigurationId)
        {
            return Ok(await _carrierConfigurationService.GetByIdAsync(carrierConfigurationId));
        }

        [HttpPost("createCarrierConfiguration")]
        public async Task<IActionResult> CreateCarrierConfiguration(CreateCarrierConfiguration request)
        {
            return Ok( await _carrierConfigurationService.CreateCarrierConfigurationAsync(request));
        }

        [HttpPut("updateCarrierConfiguration")]
        public async Task<IActionResult> UpdateCarrierConfugiration(UpdateCarrierConfiguration request)
        {
            return Ok(await _carrierConfigurationService.UpdateCarrierConfiguration(request));
        }

        [HttpDelete("deleteCarrierConfigurationId/{carrierConfigurationId}")]
        public async Task<IActionResult> DeleteCarrierConfiguration(int carrierConfigurationId)
        {
            return Ok(await _carrierConfigurationService.DeleteAsync(carrierConfigurationId));
        }

        #endregion
    }
}

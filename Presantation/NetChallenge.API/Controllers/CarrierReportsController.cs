using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace NetChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierReportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public Task<IActionResult> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

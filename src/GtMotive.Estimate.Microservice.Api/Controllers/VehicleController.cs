using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.CreateVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ListAvailableVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(CreateVehicleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody][Required] CreateVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult("Create vehicle request is invalid.");
            }

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpGet("available")]
        [ProducesResponseType(typeof(IEnumerable<ListAvailableVehiclesResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAvailable()
        {
            var presenter = await _mediator.Send(new ListAvailableVehiclesRequest());
            return presenter.ActionResult;
        }
    }
}

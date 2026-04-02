using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Api.UseCases.Rental.RentVehicle;
using GtMotive.Estimate.Microservice.Api.UseCases.Vehicle.ReturnVehicles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost]
        [ProducesResponseType(typeof(RentVehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Rent([FromBody][Required] RentVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult("Rent vehicle request is invalid.");
            }

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }

        [HttpPut]
        [ProducesResponseType(typeof(ReturnVehicleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Return([FromBody][Required] ReturnVehicleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult("Return vehicle request is invalid.");
            }

            var presenter = await _mediator.Send(request);
            return presenter.ActionResult;
        }
    }
}
